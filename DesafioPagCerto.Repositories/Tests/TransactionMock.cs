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
           return new Transaction(DateTime.Now, 100,  new decimal(99.10), new decimal(0.90),
            1, "1234");
        }

        public IEnumerable<Transaction> FindAvailable()
        {
            throw new NotImplementedException();
        }

        public bool Exist(Guid nsu)
        {
            return Guid.Empty.Equals(nsu);
        }
    }
}