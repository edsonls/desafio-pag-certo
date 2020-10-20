using System;
using System.Collections.Generic;
using System.Net.Http;
using DesafioPagCerto.Entities;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Repository.Interfaces;
using DesafioPagCerto.Services.Interfaces;

namespace DesafioPagCerto.Services
{
    public class TransactionService : ITransactionService
    {
        private const decimal TaxFixed = (decimal) 0.90;
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public Guid CreateTransaction(string numberCard, int numberInstallment,
            decimal valueTransaction)
        {
            var transaction = new Transaction(
                DateTime.Now,
                valueTransaction,
                ValueTransaction(valueTransaction),
                TaxFixed,
                numberInstallment,
                numberCard.Substring(numberCard.Length - 4)
            );

            if (ApprovedTransaction(transaction))
            {
                transaction.Approved();
                transaction.AddInstallments(CreateInstallments(numberInstallment, valueTransaction));
            }
            else
            {
                transaction.Reproved();
            }

            return _repository.Save(transaction);
        }

        private bool ApprovedTransaction(Transaction transaction) => 1000 > transaction.GrossValue;

        public IEnumerable<Installment> CreateInstallments(int numberInstallment, decimal valueTransaction)
        {
            var installments = new List<Installment>();
            var netValueForInstallment = ValueTransaction(valueTransaction) / numberInstallment;
            var grossValueForInstallment = valueTransaction / numberInstallment;
            for (var i = 0; i < numberInstallment; i++)
            {
                installments.Add(new Installment(i + 1, grossValueForInstallment, netValueForInstallment,
                    DateTime.Now.AddMonths(i + 1)));
            }

            return installments;
        }

        public Transaction Find(Guid nsu)
        {
            if (!_repository.Exist(nsu))
            {
                throw new HttpRequestException("Transaction Not Found!");
            }
            return _repository.Find(nsu);
        }

        private decimal ValueTransaction(decimal valueTransaction)
        {
            return valueTransaction - TaxFixed;
        }

        public IEnumerable<Transaction> FindAvailable()
        {
            return _repository.FindAvailable();
        }
    }
}