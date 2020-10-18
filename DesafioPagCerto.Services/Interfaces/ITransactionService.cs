using DesafioPagCerto.Entities;

namespace DesafioPagCerto.Services.Interfaces
{
    public interface ITransactionService
    {
        bool Save(Transaction transaction);

        Transaction CreateTransaction(string numberCard, int numberParcel, double valueTransaction);
    }
}