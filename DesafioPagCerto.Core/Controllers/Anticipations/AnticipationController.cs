using System;
using System.Collections.Generic;
using System.Linq;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Repository;
using DesafioPagCerto.Requests;
using DesafioPagCerto.Services;
using DesafioPagCerto.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPagCerto.Controllers.Anticipations
{
    [ApiController]
    [Route("v1/anticipation")]
    public class AnticipationController : ControllerBase
    {
        private readonly ITransactionService _transactionService = new TransactionService(new TransactionEntity());
        private readonly IAnticipationService _anticipationService = new AnticipationService(new AnticipationEntity());

        [HttpGet("available")]
        public IEnumerable<Transaction> FindAvailable()
        {
            return _transactionService.FindAvailable();
        }

        [HttpPost]
        public Guid CreateAnticipation([FromBody] IEnumerable<AnticipationRequest> anticipations)
        {
            return _anticipationService.CreateAnticipation(anticipations.Select(a =>
                _transactionService.FindTransaction(a.nsu)));
        }
    }
}