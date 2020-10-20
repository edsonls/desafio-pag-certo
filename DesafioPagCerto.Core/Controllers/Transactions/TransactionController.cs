using System;
using DesafioPagCerto.Exception;
using DesafioPagCerto.Repository;
using DesafioPagCerto.Requests;
using DesafioPagCerto.Services;
using DesafioPagCerto.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPagCerto.Controllers.Transactions
{
    [ApiController]
    [Route("v1/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService = new TransactionService(new TransactionEntity());

        [HttpPost]
        public Guid Save([FromBody] TransactionRequest transactionRequest)
        {
            return _transactionService.CreateTransaction(transactionRequest.CardNumber, transactionRequest.ParcelNumber,
                transactionRequest.TransactionValue);
        }

        [HttpGet("{nsu}")]
        public IActionResult Find(Guid nsu)
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