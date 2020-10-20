using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace DesafioPagCerto.Requests
{
    public class TransactionRequest
    {
        [StringLength(16, MinimumLength = 16)]
        [Required]
        // [CreditCard] todo ativar por ultimo
        [RegularExpression(@"(^(?!5999)\w+$)|([^-\s])")]
        public string CardNumber { get; set; }

        [Required] 
        public int ParcelNumber { get; set; }

        [Required]
        [Min(0.90)]
        public decimal TransactionValue { get; set; }
    }
}