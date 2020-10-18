using System;

namespace DesafioPagCerto.Repository.EntityFramework.Models
{
    public class Installment
    {
        public int Id { get; set; }
        public int NumberParcel { get; set; }
        public decimal GrossValue { get; set; }
        public decimal NetValue { get; set; }
        public decimal? AnticipationValue { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? TransferDate { get; set; }
        public Transaction Transaction { get; set; }
    }
}