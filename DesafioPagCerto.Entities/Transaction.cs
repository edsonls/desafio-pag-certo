using System;
using System.Collections.Generic;

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
        private double GrossValue { get; }
        private double NetValue { get; }
        private double TaxFixed { get; }
        private int NumberParcel { get; }
        private string CredCard { get; }
        private IEnumerable<Parcel> Parcels { get; }

        public Transaction(int nsu, DateTime dateTransaction, DateTime dateApproved, DateTime dateReapproved,
            bool anticipation, bool confirmation, double grossValue, double netValue, double taxFixed,
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

        public Transaction(DateTime dateTransaction, double grossValue, double netValue, double taxFixed,
            int numberParcel, string credCard, IEnumerable<Parcel> parcels)
        {
            DateTransaction = dateTransaction;
            GrossValue = grossValue;
            NetValue = netValue;
            TaxFixed = taxFixed;
            NumberParcel = numberParcel;
            CredCard = credCard;
            Parcels = parcels;
        }

        public Transaction()
        {
            throw new NotImplementedException();
        }
    }
}