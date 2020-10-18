using System;

namespace DesafioPagCerto.Entities
{
    public class Parcel
    {
        private int Id { get; }
        private int NumberParcel { get; }
        private double GrossValue { get; }
        private double NetValue { get; }
        private double? AnticipationValue { get; }
        private DateTime ExpectedDate { get; }
        private DateTime? TransferDate { get; }
        private Transaction Transaction { get; }

        public Parcel(int id, int numberParcel, double grossValue, double netValue, double? anticipationValue,
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

        public Parcel(int numberParcel, double grossValue, double netValue, DateTime expectedDate)
        {
            NumberParcel = numberParcel;
            GrossValue = grossValue;
            NetValue = netValue;
            ExpectedDate = expectedDate;
        }
    }
}