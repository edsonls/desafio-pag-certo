using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        public bool StatusAnticipation { get; set; }
        public bool Confirmation { get; set; }
        public decimal GrossValue { get; set; }
        public decimal NetValue { get; set; }
        public decimal FixedTax { get; set; }
        public int NumberParcel { get; set; }
        public string CreditCardSuffix { get; set; }

        public ICollection<Installment> Installments { get; set; }
        public Guid? AnticipationId { get; set; }
        public Anticipation Anticipation { get; set; }

        public void Update(Entities.Transactions.Transaction transaction)
        {
            TransactionDate = transaction.TransactionDate;
            ApprovedDate = transaction.ApprovedDate;
            ReprovedDate = transaction.ReprovedDate;
            StatusAnticipation = transaction.Anticipation;
            Confirmation = transaction.Confirmation;
            GrossValue = transaction.GrossValue;
            NetValue = transaction.NetValue;
            FixedTax = transaction.FixedTax;
            NumberParcel = transaction.NumberParcel;
            CreditCardSuffix = transaction.CreditCardSuffix;
            if (Installments.Any())
            {
                foreach (var installment in transaction.Installments)
                {
                    foreach (var i in Installments)
                    {
                        if (i.Id == installment.Id)
                            i.Update(installment);
                    }
                }
            }
        }
    }
}