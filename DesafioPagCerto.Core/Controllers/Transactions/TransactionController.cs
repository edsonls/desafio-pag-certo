using DesafioPagCerto.Entities;
using DesafioPagCerto.Requests;
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
            return new Transaction();
        }
    }
}