using System;

namespace DesafioPagCerto.Entities
{
    public class Transaction
    {
        private int NSU { get; }
        private DateTime DateTransaction { get; }
        private DateTime DateApproved { get; }
        private DateTime DateReapproved { get; }
        private bool Anticipation { get; }
        private bool Confirmation { get; }
        private decimal GrossValue { get; }
        private decimal NetValue { get; }
        private decimal TaxFixed { get; }
        private int NumberParcel { get; }
        private string CredCard { get; }
        private Parcel[] Parcels { get; }

        public Transaction(int nsu, DateTime dateTransaction, DateTime dateApproved, DateTime dateReapproved,
            bool anticipation, bool confirmation, decimal grossValue, decimal netValue, decimal taxFixed,
            int numberParcel, string credCard)
        {
            NSU = nsu;
            DateTransaction = dateTransaction;
            DateApproved = dateApproved;
            DateReapproved = dateReapproved;
            Anticipation = anticipation;
            Confirmation = confirmation;
            GrossValue = grossValue;
            NetValue = netValue;
            TaxFixed = taxFixed;
            NumberParcel = numberParcel;
            CredCard = credCard;
        }

        public Transaction()
        {
            throw new NotImplementedException();
        }
    }
}