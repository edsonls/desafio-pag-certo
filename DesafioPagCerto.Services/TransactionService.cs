using System;
using System.Collections.Generic;
using DesafioPagCerto.Entities;
using DesafioPagCerto.Repository.Interfaces;
using DesafioPagCerto.Services.Interfaces;

namespace DesafioPagCerto.Services
{
    public class TransactionService : ITransactionService
    {
        private const double TaxFixed = 0.90;
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public bool Save(Transaction transaction)
        {
            return _repository.Save(transaction);
        }

        public Transaction CreateTransaction(string numberCard, int numberParcel,
            double valueTransaction)
        {
            var transaction = new Transaction(
                DateTime.Now,
                valueTransaction,
                ValueTransaction(valueTransaction),
                TaxFixed,
                numberParcel,
                numberCard.Substring(-1, 4),
                CreateParcels(numberParcel, valueTransaction)
            );
            _repository.Save(transaction);
            return transaction;
        }

        private IEnumerable<Parcel> CreateParcels(int numberParcel, double valueTransaction)
        {
            var parcels = new List<Parcel>();
            var netValueForParcel = ValueTransaction(valueTransaction) / numberParcel;
            var grossValueForParcel = valueTransaction / numberParcel;
            var now = DateTime.Now;
            for (var i = 0; i < numberParcel; i++)
            {
                parcels.Add(new Parcel(i, grossValueForParcel, netValueForParcel, now.AddDays(30)));
            }

            return parcels;
        }

        private double ValueTransaction(double valueTransaction)
        {
            return (valueTransaction - TaxFixed);
        }
    }
}