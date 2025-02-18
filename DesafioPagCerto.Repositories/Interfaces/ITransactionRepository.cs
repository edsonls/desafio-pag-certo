﻿using System;
using System.Collections.Generic;
using DesafioPagCerto.Entities.Transactions;

namespace DesafioPagCerto.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        Transaction Save(Transaction transaction);
        Transaction Find(Guid NSU);
        IEnumerable<Transaction> FindAvailable();
        bool Exist(Guid nsu);
    }
}