using System;
using System.Collections.Generic;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Exception;
using DesafioPagCerto.Repository.Tests;
using DesafioPagCerto.Services;
using DesafioPagCerto.Services.Interfaces;
using NUnit.Framework;

namespace DesafioPagCerto.Tests
{
    public class AnticipationServiceTest
    {
        private readonly IAnticipationService _transactionService = new AnticipationService(new AnticipationMock());
        private readonly List<Transaction> _transactionMock = new List<Transaction>();

        [SetUp]
        public void Setup()
        {
            _transactionMock.Add(new Transaction(
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
            ));
        }

        [Test]
        public void TestCreateAnticipationNotOk()
        {
            var transactionService = new AnticipationService(new AnticipationMock(true));
            Assert.Throws<ForbiddenException>(() => transactionService.CreateAnticipation(_transactionMock));
        }

        [Test]
        public void TestCreateAnticipationOk()
        {
            Assert.NotNull(_transactionService.CreateAnticipation(_transactionMock));
        }

        [Test]
        public void TestCreateAnticipationTransactionNotOk()
        {
            var transactionService = new AnticipationService(new AnticipationMock(true));
            Assert.Throws<ForbiddenException>(() => _transactionService.CreateAnticipation(_transactionMock));
        }
    }
}