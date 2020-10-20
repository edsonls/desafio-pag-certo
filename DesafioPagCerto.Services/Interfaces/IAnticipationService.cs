using System;
using System.Collections.Generic;
using DesafioPagCerto.Entities.Anticipations;
using DesafioPagCerto.Entities.Transactions;

namespace DesafioPagCerto.Services.Interfaces
{
    public interface IAnticipationService
    {
        Guid CreateAnticipation(IEnumerable<Transaction> transactions);
        Anticipation Start(Guid anticipationId);
        Anticipation Finish(Guid anticipationId, IEnumerable<Guid> transactionsApproved);
        bool AnticipationInOpen();
    }
}