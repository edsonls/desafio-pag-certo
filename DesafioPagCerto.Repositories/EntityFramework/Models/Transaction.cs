using System;
using System.Collections.Generic;

namespace DesafioPagCerto.Repository.EntityFramework.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int NSU { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public DateTime ReprovedDate { get; set; }
        public bool Anticipation { get; set; }
        public bool Confirmation { get; set; }
        public decimal GrossValue { get; set; }
        public decimal NetValue { get; set; }
        public decimal FixedTax { get; set; }
        public int NumberParcel { get; set; }
        public string CreditCardSuffix { get; set; }

        public ICollection<Installment> Installments { get; set; }
    }
}