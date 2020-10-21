using System;
using System.Collections.Generic;
using System.Linq;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Enum;
using DesafioPagCerto.Exception;
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
        public IActionResult CreateAnticipation([FromBody] IEnumerable<AnticipationRequest> anticipations)
        {
            try
            {
                return Ok(_anticipationService.CreateAnticipation(
                    _transactionService.CheckAvailable(anticipations.Select(a => a.nsu))));
            }
            catch (ForbiddenException n)
            {
                return Forbid(n.Message);
            }
            catch (NotFoundException n)
            {
                return NotFound(n.Message);
            }
        }

        [HttpGet]
        [HttpGet("{status}")]
        public IActionResult List(StatusAnticipations? status = null)
        {
            try
            {
                return Ok(_anticipationService.ListAll(status));
            }
            catch (NotFoundException n)
            {
                return NotFound(n.Message);
            }
        }

        [HttpPut("start/{anticipationId}")]
        public IActionResult Start(Guid anticipationId)
        {
            try
            {
                return Ok(_anticipationService.Start(anticipationId));
            }
            catch (ForbiddenException n)
            {
                return Forbid(n.Message);
            }
            catch (NotFoundException n)
            {
                return NotFound(n.Message);
            }
        }

        [HttpPut("finish/{anticipationId}")]
        public IActionResult Finish(Guid anticipationId,
            [FromBody] IEnumerable<AnticipationRequest> transactionsApproved)
        {
            try
            {
                return Ok(_anticipationService.Finish(anticipationId, transactionsApproved.Select(a => a.nsu)));
            }
            catch (ForbiddenException n)
            {
                return Forbid(n.Message);
            }
            catch (NotFoundException n)
            {
                return NotFound(n.Message);
            }
        }
    }
}