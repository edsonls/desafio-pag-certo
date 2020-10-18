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
        public DateTime? AnalysisStartDate { get; }
        public DateTime? AnalysisEndDate { get; }
        public ResultAnalysisEnum? ResultAnalysis { get; }
        public StatusAnticipations StatusAnticipation { get; }
        public decimal RequestedAmount { get; }
        public decimal AnticipatedAmount { get; }
        public IEnumerable<Transaction> Transactions { get; }

        public Anticipation(DateTime solicitationDate, decimal requestedAmount,
            IEnumerable<Transaction> transactions,
            StatusAnticipations statusAnticipation = StatusAnticipations.Wait)
        {
            SolicitationDate = solicitationDate;
            StatusAnticipation = statusAnticipation;
            RequestedAmount = requestedAmount;
            Transactions = transactions;
        }
    }
}