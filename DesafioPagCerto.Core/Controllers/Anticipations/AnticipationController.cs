using System.Collections.Generic;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Repository;
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

        [HttpGet("available")]
        public IEnumerable<Transaction> FindAvailable()
        {
            return _transactionService.FindAvailable();
        }
    }
}