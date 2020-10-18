using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioPagCerto.Repository.EntityFramework.Models
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid NSU { get; set; }

        public DateTime TransactionDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? ReprovedDate { get; set; }
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