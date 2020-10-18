using System;
using System.Collections.Generic;
using DesafioPagCerto.Entities;
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

        public Transaction CreateTransaction(string numberCard, int numberInstallment,
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

            _repository.Save(transaction);
            return transaction;
        }

        private bool ApprovedTransaction(Transaction transaction) => 1000 > transaction.GrossValue;

        public IEnumerable<Installment> CreateInstallments(int numberInstallment, decimal valueTransaction)
        {
            var installments = new List<Installment>();
            var netValueForInstallment = ValueTransaction(valueTransaction) / numberInstallment;
            var grossValueForInstallment = valueTransaction / numberInstallment;
            for (var i = 0; i < numberInstallment; i++)
            {
                installments.Add(new Installment(i, grossValueForInstallment, netValueForInstallment,
                    DateTime.Now.AddMonths(i + 1)));
            }

            return installments;
        }

        private decimal ValueTransaction(decimal valueTransaction)
        {
            return valueTransaction - TaxFixed;
        }
    }
}