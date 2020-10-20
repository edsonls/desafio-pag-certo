using System;
using System.Collections.Generic;
using System.Linq;
using DesafioPagCerto.Entities.Anticipations;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Enum;
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
            var transactions = anticipations.Select(a =>
                _transactionService.FindTransaction(a.nsu));
            return _anticipationService.CreateAnticipation(transactions);
        }

        [HttpGet]
        [HttpGet("{status}")]
        public IEnumerable<Anticipation> List(ResultAnalysisEnum? status = null)
        {
            return _anticipationService.ListAll(status);
        }

        [HttpPut("start/{anticipationId}")]
        public Anticipation Start(Guid anticipationId)
        {
            return _anticipationService.Start(anticipationId);
        }

        [HttpPut("finish/{anticipationId}")]
        public Anticipation Finish(Guid anticipationId,
            [FromBody] IEnumerable<AnticipationRequest> transactionsApproved)
        {
            return _anticipationService.Finish(anticipationId, transactionsApproved.Select(a => a.nsu));
        }
    }
}