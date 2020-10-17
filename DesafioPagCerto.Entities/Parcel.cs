using System;

namespace DesafioPagCerto.Entities
{
    public class Parcel
    {
        private int Id { get; }
        private int NumberParcel { get; }
        private decimal GrossValue { get; }
        private decimal NetValue { get; }
        private decimal? AnticipationValue { get; }
        private DateTime ExpectedDate { get; }
        private DateTime? TransferDate { get; }
        private Transaction Transaction { get; }

        public Parcel(int id, int numberParcel, decimal grossValue, decimal netValue, decimal? anticipationValue,
            DateTime expectedDate, DateTime? transferDate, Transaction transaction)
        {
            Id = id;
            NumberParcel = numberParcel;
            GrossValue = grossValue;
            NetValue = netValue;
            AnticipationValue = anticipationValue;
            ExpectedDate = expectedDate;
            TransferDate = transferDate;
            Transaction = transaction;
        }
    }
}