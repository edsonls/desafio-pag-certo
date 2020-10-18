using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioPagCerto.Entities
{
    public class Transaction
    {
        public Guid NSU { get; }
        public DateTime TransactionDate { get; }
        public DateTime? ApprovedDate { get; private set; }
        public DateTime? ReprovedDate { get; private set; }
        public bool Anticipation { get; }
        public bool Confirmation { get; private set; }
        public decimal GrossValue { get; }
        public decimal NetValue { get; }
        public decimal FixedTax { get; }
        public int NumberParcel { get; }
        public string CreditCardSuffix { get; }
        public IEnumerable<Installment> Installments { get; private set; }

        public Transaction(Guid nsu, DateTime transactionDate, DateTime? approvedDate, DateTime? reprovedDate,
            bool anticipation, bool confirmation, decimal grossValue, decimal netValue, decimal fixedTax,
            int numberParcel, string creditCardSuffix)
        {
            NSU = nsu;
            TransactionDate = transactionDate;
            ApprovedDate = approvedDate;
            ReprovedDate = reprovedDate;
            Anticipation = anticipation;
            Confirmation = confirmation;
            GrossValue = grossValue;
            NetValue = netValue;
            FixedTax = fixedTax;
            NumberParcel = numberParcel;
            CreditCardSuffix = creditCardSuffix;
        }

        public Transaction(Guid nsu, DateTime transactionDate, DateTime? approvedDate, DateTime? reprovedDate,
            bool anticipation, bool confirmation, decimal grossValue, decimal netValue, decimal fixedTax,
            int numberParcel, string creditCardSuffix, IEnumerable<Installment> installments)
        {
            NSU = nsu;
            TransactionDate = transactionDate;
            ApprovedDate = approvedDate;
            ReprovedDate = reprovedDate;
            Anticipation = anticipation;
            Confirmation = confirmation;
            GrossValue = grossValue;
            NetValue = netValue;
            FixedTax = fixedTax;
            NumberParcel = numberParcel;
            CreditCardSuffix = creditCardSuffix;
            Installments = installments;
        }

        public Transaction(DateTime transactionDate, decimal grossValue, decimal netValue, decimal fixedTax,
            int numberParcel, string creditCardSuffix)
        {
            TransactionDate = transactionDate;
            GrossValue = grossValue;
            NetValue = netValue;
            FixedTax = fixedTax;
            NumberParcel = numberParcel;
            CreditCardSuffix = creditCardSuffix;
        }

        public Transaction()
        {
            throw new NotImplementedException();
        }

        public void Approved()
        {
            ApprovedDate = DateTime.Now;
            Confirmation = true;
        }

        public void Reproved()
        {
            ReprovedDate = DateTime.Now;
        }

        public void AddInstallments(IEnumerable<Installment> installments)
        {
            Installments ??= installments;
        }
    }
}