using System;
using System.Linq;
using DesafioPagCerto.Repository.EntityFramework.Drive;
using DesafioPagCerto.Entities.Anticipations;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Repository.Interfaces;
using AnticipationModel = DesafioPagCerto.Repository.EntityFramework.Models.Anticipation;
using TransactionModel = DesafioPagCerto.Repository.EntityFramework.Models.Transaction;

namespace DesafioPagCerto.Repository
{
    public class AnticipationEntity : IAnticipationRepository
    {
        public bool AnticipationInOpen()
        {
            return false; //todo
        }

        public Guid Save(Anticipation anticipation)
        {
            using var drive = new Drive();
            drive.Database.BeginTransaction();
            try
            {
                var model = ToModel(anticipation);
                var nsus = anticipation.Transactions.Select(at => at.NSU);
                model.Transactions = drive.Transaction
                    .Where(t => nsus.Contains(t.NSU))
                    .ToList();
                drive.Anticipation.Add(model);
                drive.SaveChanges();
                drive.Database.CommitTransaction();
                return model.Id;
            }
            catch (Exception)
            {
                drive.Database.RollbackTransaction();
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