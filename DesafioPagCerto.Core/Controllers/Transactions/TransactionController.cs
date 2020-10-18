using System;
using DesafioPagCerto.Entities;
using DesafioPagCerto.Repository;
using DesafioPagCerto.Requests;
using DesafioPagCerto.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPagCerto.Controllers.Transactions
{
    [ApiController]
    [Route("v1/transaction")]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        public Guid Save([FromBody] TransactionRequest transactionRequest)
        {
            var service = new TransactionService(new TransactionEntity());
            return service.CreateTransaction(transactionRequest.CardNumber, transactionRequest.ParcelNumber,
                transactionRequest.TransactionValue);
        }
        [HttpGet("{nsu}")]
        public Transaction Find(Guid nsu)
        {
            var service = new TransactionService(new TransactionEntity());
            return service.FindTransaction(nsu);
        }
    }
}