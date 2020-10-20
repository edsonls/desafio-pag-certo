using System;
using System.Collections.Generic;
using System.Linq;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Enum;

namespace DesafioPagCerto.Entities.Anticipations
{
    public class Anticipation
    {
        public Guid Id { get; }
        public DateTime SolicitationDate { get; }
        public DateTime? AnalysisStartDate { get; private set; }
        public DateTime? AnalysisEndDate { get; private set; }
        public ResultAnalysisEnum? ResultAnalysis { get; private set; }
        public StatusAnticipations StatusAnticipation { get; private set; }
        public decimal RequestedAmount { get; }
        public decimal AnticipatedAmount { get; private set;}
        public IEnumerable<Transaction> Transactions { get; private set;}

        public Anticipation(DateTime solicitationDate, decimal requestedAmount,
            IEnumerable<Transaction> transactions,
            StatusAnticipations statusAnticipation = StatusAnticipations.Pending)
        {
            SolicitationDate = solicitationDate;
            StatusAnticipation = statusAnticipation;
            RequestedAmount = requestedAmount;
            Transactions = transactions;
        }

        public Anticipation(Guid id, DateTime solicitationDate, DateTime? analysisStartDate, DateTime? analysisEndDate,
            ResultAnalysisEnum? resultAnalysis, StatusAnticipations statusAnticipation, decimal requestedAmount,
            decimal anticipatedAmount, IEnumerable<Transaction> transactions)
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

        public List<Transaction> Approved(IEnumerable<Guid> transactionsApproved, decimal taxFixed)
        {
            AnalysisEndDate = DateTime.Now;
            StatusAnticipation = StatusAnticipations.Finish;
            var transactions = Transactions
                .Where(t => transactionsApproved.Contains(t.NSU))
                .ToList();
            AnticipatedAmount = transactions.Sum(t=> t.AnticipatedAmount(taxFixed));
            if (transactions.Count == Transactions.Count())
                ResultAnalysis = ResultAnalysisEnum.Approved;
            else if (Transactions.Count() > transactions.Count)
                ResultAnalysis = ResultAnalysisEnum.PartiallyApproved;
            else
                ResultAnalysis = ResultAnalysisEnum.Reproved;
            Transactions = transactions;
            return transactions;
        }
    }
}