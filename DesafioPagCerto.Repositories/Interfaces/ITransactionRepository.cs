using System;
using DesafioPagCerto.Entities;

namespace DesafioPagCerto.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        public Guid Save(Transaction transaction);
        Transaction find(Guid NSU);
    }
}