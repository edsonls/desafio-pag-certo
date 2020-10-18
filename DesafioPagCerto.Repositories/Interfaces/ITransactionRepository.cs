using System;
using System.Collections.Generic;
using DesafioPagCerto.Entities;

namespace DesafioPagCerto.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        public Guid Save(Transaction transaction);
        Transaction Find(Guid NSU);
        IEnumerable<Transaction> FindAvailable();
    }
}