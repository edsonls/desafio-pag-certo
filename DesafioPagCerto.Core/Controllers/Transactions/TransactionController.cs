using DesafioPagCerto.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPagCerto.Controllers.Transactions
{
    [ApiController]
    [Route("transaction/v1")]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        public Transaction save()
        {
            return new Transaction();
        }
    }
}