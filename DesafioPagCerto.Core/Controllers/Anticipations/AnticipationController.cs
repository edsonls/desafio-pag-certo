using System.Collections.Generic;
using DesafioPagCerto.Entities;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Repository;
using DesafioPagCerto.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPagCerto.Controllers.Anticipations
{
    [ApiController]
    [Route("v1/anticipation")]
    public class AnticipationController : ControllerBase
    {
        
        [HttpGet("available")]
        public IEnumerable<Transaction> FindAvailable()
        {
            var service = new TransactionService(new TransactionEntity());
            return service.FindAvailable();
        }
    }
}