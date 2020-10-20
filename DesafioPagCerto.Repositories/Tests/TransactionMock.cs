using System;
using System.Collections.Generic;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Repository.Interfaces;

namespace DesafioPagCerto.Repository.Tests
{
    public class TransactionMock : ITransactionRepository
    {
        public Transaction Save(Transaction transaction)
        {
            return transaction;
        }

        public Transaction Find(Guid NSU)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> FindAvailable()
        {
            throw new NotImplementedException();
        }

        public bool Exist(Guid nsu)
        {
            throw new NotImplementedException();
        }
    }
}