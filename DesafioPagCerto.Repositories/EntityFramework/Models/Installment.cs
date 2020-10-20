using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioPagCerto.Repository.EntityFramework.Models
{
    public class Installment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public int NumberParcel { get; set; }
        public decimal GrossValue { get; set; }
        public decimal NetValue { get; set; }
        public decimal? AnticipationValue { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? TransferDate { get; set; }
        public Transaction Transaction { get; set; }

        public void Update(Entities.Transactions.Installment installment)
        {
            NumberParcel = installment.NumberParcel;
            GrossValue = installment.GrossValue;
            NetValue = installment.NetValue;
            AnticipationValue = installment.AnticipationValue;
            ExpectedDate = installment.ExpectedDate;
            TransferDate = installment.TransferDate;
        }
    }
}