using System;
using System.Collections.Generic;
using DesafioPagCerto.Entities.Transactions;

namespace DesafioPagCerto.Services.Interfaces
{
    public interface ITransactionService
    {
        Guid CreateTransaction(string numberCard, int numberParcel, decimal valueTransaction);
        IEnumerable<Installment> CreateInstallments(int numberInstallment, decimal valueTransaction);
        Transaction Find(Guid NSU);
        IEnumerable<Transaction> FindAvailable();
    }
}