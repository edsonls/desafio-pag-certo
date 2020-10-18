﻿using System;
using System.Collections.Generic;
using DesafioPagCerto.Entities;

namespace DesafioPagCerto.Services.Interfaces
{
    public interface ITransactionService
    {
    
        Guid CreateTransaction(string numberCard, int numberParcel, decimal valueTransaction);
        IEnumerable<Installment> CreateInstallments(int numberInstallment, decimal valueTransaction);
        Transaction FindTransaction(Guid NSU);
    }
}