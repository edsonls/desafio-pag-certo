using System;
using System.Collections.Generic;
using DesafioPagCerto.Entities.Anticipations;
using DesafioPagCerto.Enum;
using DesafioPagCerto.Repository.Interfaces;

namespace DesafioPagCerto.Repository.Tests
{
    public class AnticipationMock : IAnticipationRepository
    {
        public bool AnticipationInOpen()
        {
            throw new NotImplementedException();
        }

        public Guid Save(Anticipation anticipation)
        {
            throw new NotImplementedException();
        }

        public Anticipation Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Anticipation anticipation)
        {
            throw new NotImplementedException();
        }

        public Anticipation Reproved(Anticipation anticipation)
        {
            throw new NotImplementedException();
        }

        public Anticipation Approved(Anticipation anticipation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Anticipation> ListAll(StatusAnticipations? status)
        {
            throw new NotImplementedException();
        }

        public bool Exist(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}