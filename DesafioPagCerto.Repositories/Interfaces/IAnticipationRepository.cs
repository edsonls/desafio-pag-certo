using System;
using System.Collections.Generic;
using DesafioPagCerto.Entities.Anticipations;
using DesafioPagCerto.Enum;

namespace DesafioPagCerto.Repository.Interfaces
{
    public interface IAnticipationRepository
    {
        bool AnticipationInOpen();
        
        public Guid Save(Anticipation anticipation);
        Anticipation Find(Guid id);
        bool Edit(Anticipation anticipation);
        Anticipation Reproved(Anticipation anticipation);
        Anticipation Approved(Anticipation anticipation);
        IEnumerable<Anticipation> ListAll(ResultAnalysisEnum? status);
        bool Exist(Guid id);
    }
}