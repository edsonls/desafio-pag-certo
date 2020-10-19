using System;
using System.Collections.Generic;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Enum;

namespace DesafioPagCerto.Entities.Anticipations
{
    public class Anticipation
    {
        public Guid Id { get; }
        public DateTime SolicitationDate { get; }
        public DateTime? AnalysisStartDate { get; private set; }
        public DateTime? AnalysisEndDate { get; }
        public ResultAnalysisEnum? ResultAnalysis { get; }
        public StatusAnticipations StatusAnticipation { get; private set; }
        public decimal RequestedAmount { get; }
        public decimal AnticipatedAmount { get; }
        public IEnumerable<Transaction> Transactions { get; }

        public Anticipation(DateTime solicitationDate, decimal requestedAmount,
            IEnumerable<Transaction> transactions,
            StatusAnticipations statusAnticipation = StatusAnticipations.Pending)
        {
            SolicitationDate = solicitationDate;
            StatusAnticipation = statusAnticipation;
            RequestedAmount = requestedAmount;
            Transactions = transactions;
        }

        public Anticipation(Guid id, DateTime solicitationDate, DateTime? analysisStartDate, DateTime? analysisEndDate, ResultAnalysisEnum? resultAnalysis, StatusAnticipations statusAnticipation, decimal requestedAmount, decimal anticipatedAmount, IEnumerable<Transaction> transactions)
        {
            Id = id;
            SolicitationDate = solicitationDate;
            AnalysisStartDate = analysisStartDate;
            AnalysisEndDate = analysisEndDate;
            ResultAnalysis = resultAnalysis;
            StatusAnticipation = statusAnticipation;
            RequestedAmount = requestedAmount;
            AnticipatedAmount = anticipatedAmount;
            Transactions = transactions;
        }

        public Anticipation()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            StatusAnticipation = StatusAnticipations.InAnalysis;
            AnalysisStartDate = DateTime.Now;
        }
    }
}