using System.ComponentModel.DataAnnotations;

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
        public decimal TransactionValue { get; set; }
    }
}