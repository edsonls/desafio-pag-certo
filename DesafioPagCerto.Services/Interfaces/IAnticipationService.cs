using System;
using System.Collections.Generic;
using DesafioPagCerto.Entities.Transactions;

namespace DesafioPagCerto.Services.Interfaces
{
    public interface IAnticipationService
    {
        Guid CreateAnticipation(IEnumerable<Transaction> transactions);
    }
}