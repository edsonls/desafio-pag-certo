using System;

namespace DesafioPagCerto.Entities
{
    public class Installment
    {
        public int Id { get; }
        public int NumberParcel { get; }
        public decimal GrossValue { get; }
        public decimal NetValue { get; }
        public decimal? AnticipationValue { get; }
        public DateTime ExpectedDate { get; }
        public DateTime? TransferDate { get; }

        public Installment(int id, int numberParcel, decimal grossValue, decimal netValue, decimal? anticipationValue,
            DateTime expectedDate, DateTime? transferDate)
        {
            Id = id;
            NumberParcel = numberParcel;
            GrossValue = grossValue;
            NetValue = netValue;
            AnticipationValue = anticipationValue;
            ExpectedDate = expectedDate;
            TransferDate = transferDate;
        }

        public Installment(int numberParcel, decimal grossValue, decimal netValue, DateTime expectedDate)
        {
            NumberParcel = numberParcel;
            GrossValue = grossValue;
            NetValue = netValue;
            ExpectedDate = expectedDate;
        }
    }
}