using System;
using DesafioPagCerto.Entities;
using DesafioPagCerto.Repository.Interfaces;

namespace DesafioPagCerto.Repository
{
    public class TransactionEntity : ITransactionRepository
    {
        public bool Save(Transaction transaction)
        {
            Console.WriteLine(transaction);
            return true;
        }
    }
}