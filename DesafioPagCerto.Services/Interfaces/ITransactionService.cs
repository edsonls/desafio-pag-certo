using DesafioPagCerto.Entities;

namespace DesafioPagCerto.Services.Interfaces
{
    public interface ITransactionService
    {
        public bool Save(Transaction transaction);
    }
}