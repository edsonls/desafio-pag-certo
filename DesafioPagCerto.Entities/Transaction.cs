using System;

namespace DesafioPagCerto.Entities
{
    public class Transaction
    {
        private int NSU { get; }
        private DateTime DateTransaction { get;}
        private DateTime DateApproved { get;}
        private DateTime DateReapproved { get;}
        private bool Anticipation { get;}
        private bool Confirmation { get;}
        private decimal GrossValue { get;}
        private decimal NetValue { get;}
        private decimal TaxFixed { get;}
        private int NumberParcel { get;}
        private string CredCard { get;}
    }
}