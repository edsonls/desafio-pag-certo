using System;
using DesafioPagCerto.Entities.Anticipations;

namespace DesafioPagCerto.Repository.Interfaces
{
    public interface IAnticipationRepository
    {
        bool AnticipationInOpen();
        
        public Guid Save(Anticipation anticipation);
        Anticipation Find(Guid id);
        bool Edit(Anticipation anticipation);
    }
}