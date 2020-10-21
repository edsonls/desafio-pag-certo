using System;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Exception;
using DesafioPagCerto.Repository;
using DesafioPagCerto.Requests;
using DesafioPagCerto.Services;
using DesafioPagCerto.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPagCerto.Controllers.Transactions
{
    [ApiController]
    [Route("v1/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService = new TransactionService(new TransactionEntity());

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Transaction Save([FromBody] TransactionRequest transactionRequest)
        {
            return _transactionService.CreateTransaction(transactionRequest.CardNumber, transactionRequest.ParcelNumber,
                transactionRequest.TransactionValue);
        }

        [HttpGet("{nsu}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Transaction> Find(Guid nsu)
        {
            try
            {
                return Ok(_transactionService.Find(nsu));
            }
            catch (NotFoundException n)
            {
                return NotFound(n.Message);
            }
        }
    }
}