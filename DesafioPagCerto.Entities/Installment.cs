using System;

namespace DesafioPagCerto.Entities
{
    public class Installment
    {
        public Guid Id { get; }
        public int NumberParcel { get; }
        public decimal GrossValue { get; }
        public decimal NetValue { get; }
        public decimal? AnticipationValue { get; }
        public DateTime ExpectedDate { get; }
        public DateTime? TransferDate { get; }
        public Guid TransactionNSU { get; }

        public Installment(Guid id, int numberParcel, decimal grossValue, decimal netValue, decimal? anticipationValue,
            DateTime expectedDate, DateTime? transferDate, Guid transactionNSU)
        {
            Id = id;
            NumberParcel = numberParcel;
            GrossValue = grossValue;
            NetValue = netValue;
            AnticipationValue = anticipationValue;
            ExpectedDate = expectedDate;
            TransferDate = transferDate;
            TransactionNSU = transactionNSU;
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