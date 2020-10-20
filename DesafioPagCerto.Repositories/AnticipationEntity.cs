using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using DesafioPagCerto.Repository.EntityFramework.Drive;
using DesafioPagCerto.Entities.Anticipations;
using DesafioPagCerto.Enum;
using DesafioPagCerto.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using AnticipationModel = DesafioPagCerto.Repository.EntityFramework.Models.Anticipation;
using TransactionModel = DesafioPagCerto.Repository.EntityFramework.Models.Transaction;

namespace DesafioPagCerto.Repository
{
    public class AnticipationEntity : IAnticipationRepository
    {
        private readonly Drive _drive = new Drive();

        public bool AnticipationInOpen()
        {
            return _drive.Anticipation.Any(a =>
                a.StatusAnticipation == StatusAnticipations.InAnalysis ||
                a.StatusAnticipation == StatusAnticipations.Pending);
        }

        public Guid Save(Anticipation anticipation)
        {
            _drive.Database.BeginTransaction();
            try
            {
                var model = ToModel(anticipation);
                var nsus = anticipation.Transactions.Select(at => at.NSU);
                model.Transactions = _drive.Transaction
                    .Where(t => nsus.Contains(t.NSU))
                    .ToList();
                _drive.Anticipation.Add(model);
                _drive.SaveChanges();
                _drive.Database.CommitTransaction();
                return model.Id;
            }
            catch (Exception)
            {
                _drive.Database.RollbackTransaction();
                throw new Exception("Erro ao salvar antecipação");
            }
        }

        public Anticipation Find(Guid id)
        {
            var anticipationModel = _drive.Anticipation
                .Where(a => a.Id == id)
                .Include(a => a.Transactions)
                .FirstOrDefault();
            return ToEntity(anticipationModel);
        }

        public bool Edit(Anticipation anticipation)
        {
            var anticipationModel = _drive.Anticipation.First(a => a.Id == anticipation.Id);
            anticipationModel.Update(anticipation, false);
            return _drive.SaveChanges() > 0;
        }

        private AnticipationModel ToModel(Anticipation anticipation)
        {
            return new AnticipationModel
            {
                AnticipatedAmount = anticipation.AnticipatedAmount,
                RequestedAmount = anticipation.RequestedAmount,
                ResultAnalysis = anticipation.ResultAnalysis,
                SolicitationDate = anticipation.SolicitationDate,
                StatusAnticipation = anticipation.StatusAnticipation,
                AnalysisEndDate = anticipation.AnalysisEndDate,
                AnalysisStartDate = anticipation.AnalysisStartDate
            };
        }

        private Anticipation ToEntity(AnticipationModel anticipation)
        {
            var repositoryTransaction = new TransactionEntity();
            return new Anticipation
            (
                anticipatedAmount: anticipation.AnticipatedAmount,
                requestedAmount: anticipation.RequestedAmount,
                resultAnalysis: anticipation.ResultAnalysis,
                solicitationDate: anticipation.SolicitationDate,
                statusAnticipation: anticipation.StatusAnticipation,
                analysisEndDate: anticipation.AnalysisEndDate,
                analysisStartDate: anticipation.AnalysisStartDate,
                id: anticipation.Id,
                transactions: anticipation.Transactions.Select(at => repositoryTransaction.Find(at.NSU))
            );
        }

        public Anticipation Reproved(Anticipation anticipation)
        {
            Edit(anticipation);
            return Find(anticipation.Id);
        }

        public Anticipation Approved(Anticipation anticipation)
        {
            var anticipationModel =
                _drive.Anticipation
                    .Include("Transactions.Installments")
                    .First(a => a.Id == anticipation.Id);
            anticipationModel.Update(anticipation);
            _drive.SaveChanges();
            return Find(anticipation.Id);
        }

        public IEnumerable<Anticipation> ListAll(ResultAnalysisEnum? status)
        {
            return status == null
                ? _drive.Anticipation
                    .Include("Transactions")
                    .ToList()
                    .Select(ToEntity)
                : _drive.Anticipation
                    .Include("Transactions")
                    .Where(a => a.ResultAnalysis == status)
                    .ToList()
                    .Select(ToEntity);
        }


        public bool Exist(Guid id)
        {
            return _drive.Anticipation
                .Any(a => a.Id == id);
        }
    }
}