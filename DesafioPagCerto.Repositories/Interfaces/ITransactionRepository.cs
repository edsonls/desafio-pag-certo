using DesafioPagCerto.Entities;

namespace DesafioPagCerto.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        public bool Save(Transaction transaction);
    }
}