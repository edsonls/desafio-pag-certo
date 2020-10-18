using System;
using System.Linq;
using DesafioPagCerto.Repository.EntityFramework.Drive;
using DesafioPagCerto.Entities.Anticipations;
using DesafioPagCerto.Enum;
using DesafioPagCerto.Repository.Interfaces;
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
                a.StatusAnticipation == StatusAnticipations.Wait);
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
    }
}