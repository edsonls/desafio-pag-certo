using System;

namespace DesafioPagCerto.Requests
{
    public class TransactionRequest
    {
        private string NumberCard { get; set; }
        private int NumberParcel { get; set; }
        private float ValueTransaction { get; set; }

        public TransactionRequest()
        {
            ValidateRequest();
        }

        private void ValidateRequest()
        {
            if (NumberCard.Length != 16)
                throw new Exception("Número do cartão inválido");

            if (NumberCard.StartsWith("5999"))
                throw new Exception("Número do cartão inválido");

            if (NumberParcel <= 0)
                throw new Exception("Valor da parcela deve ser maior ou igua a 1");

            if (ValueTransaction <= 0.90)
                throw new Exception("Valor da transação deve ser maior que R$ 0.90");
        }
    }
}