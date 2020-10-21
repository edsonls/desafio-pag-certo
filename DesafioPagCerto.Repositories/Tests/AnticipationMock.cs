using System;
using System.Collections.Generic;
using DesafioPagCerto.Entities.Anticipations;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Enum;
using DesafioPagCerto.Repository.Interfaces;

namespace DesafioPagCerto.Repository.Tests
{
    public class AnticipationMock : IAnticipationRepository
    {
        private readonly bool _anticipationInOpen;
        private readonly StatusAnticipations _statusAnticipations;
        private readonly bool _edit;

        public AnticipationMock(bool anticipationInOpen = false,
            StatusAnticipations statusAnticipations = StatusAnticipations.Pending,
            bool edit = true)
        {
            _anticipationInOpen = anticipationInOpen;
            _statusAnticipations = statusAnticipations;
            _edit = edit;
        }

        public bool AnticipationInOpen()
        {
            return _anticipationInOpen;
        }

        public Guid Save(Anticipation anticipation)
        {
            return new Guid();
        }

        public Anticipation Find(Guid id)
        {
            return new Anticipation(id, DateTime.Now, DateTime.Now, DateTime.Now, null, _statusAnticipations,
                1000, 0,
                new[]
                {
                    new Transaction(
                        new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6"),
                        DateTime.Now,
                        null,
                        null,
                        false,
                        true, 100,
                        (decimal) 99.10,
                        (decimal) 0.90,
                        1,
                        "5689", new[]
                        {
                            new Installment(
                                new Guid("B6DD6D1A-33F6-411D-736C-08D8750151BD"),
                                1,
                                100,
                                (decimal) 99.10,
                                null,
                                DateTime.Now,
                                null,
                                new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6")
                            )
                        }
                    ),
                    new Transaction(
                        new Guid("E2DB4B89-EF82-49A1-5439-08D87502610B"),
                        DateTime.Now,
                        null,
                        null,
                        false,
                        true, 100,
                        (decimal) 99.10,
                        (decimal) 0.90,
                        1,
                        "5689", new[]
                        {
                            new Installment(
                                new Guid("B6DD6D1A-33F6-411D-736C-08D8750151BD"),
                                1,
                                100,
                                (decimal) 99.10,
                                null,
                                DateTime.Now,
                                null,
                                new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6")
                            )
                        }
                    )
                });
        }

        public bool Edit(Anticipation anticipation)
        {
            return _edit;
        }

        public Anticipation Reproved(Anticipation anticipation)
        {
            return anticipation;
        }

        public Anticipation Approved(Anticipation anticipation)
        {
            return anticipation;
        }

        public IEnumerable<Anticipation> ListAll(StatusAnticipations? status)
        {
            throw new NotImplementedException();
        }

        public bool Exist(Guid id)
        {
            return new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6").Equals(id);
        }
    }
}