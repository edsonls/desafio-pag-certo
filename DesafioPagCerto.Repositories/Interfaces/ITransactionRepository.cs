using DesafioPagCerto.Entities;

namespace DesafioPagCerto.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        public int Save(Transaction transaction);
    }
}