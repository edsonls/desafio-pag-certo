using System;
using DesafioPagCerto.Entities;
using DesafioPagCerto.Repository.Interfaces;
using DesafioPagCerto.Services.Interfaces;

namespace DesafioPagCerto.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public bool Save(Transaction transaction)
        {
            return _repository.Save(transaction);
        }
    }
}