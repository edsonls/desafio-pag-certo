using DesafioPagCerto.Entities;
using DesafioPagCerto.Repository;
using DesafioPagCerto.Requests;
using DesafioPagCerto.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPagCerto.Controllers.Transactions
{
    [ApiController]
    [Route("transaction/v1")]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        public Transaction Save([FromBody] TransactionRequest transactionRequest)
        {
            var service = new TransactionService(new TransactionEntity());
            return service.CreateTransaction(transactionRequest.CardNumber, transactionRequest.ParcelNumber,
                transactionRequest.TransactionValue);
        }
    }
}