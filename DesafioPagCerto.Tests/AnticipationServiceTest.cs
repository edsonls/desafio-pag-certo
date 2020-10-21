using System;
using System.Collections.Generic;
using System.Linq;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Enum;
using DesafioPagCerto.Exception;
using DesafioPagCerto.Repository.Tests;
using DesafioPagCerto.Services;
using DesafioPagCerto.Services.Interfaces;
using NUnit.Framework;

namespace DesafioPagCerto.Tests
{
    public class AnticipationServiceTest
    {
        private readonly IAnticipationService _anticipationService = new AnticipationService(new AnticipationMock());
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
            var anticipationService = new AnticipationService(new AnticipationMock(true));
            Assert.Throws<ForbiddenException>(() => anticipationService.CreateAnticipation(_transactionMock));
        }

        [Test]
        public void TestCreateAnticipationOk()
        {
            Assert.NotNull(_anticipationService.CreateAnticipation(_transactionMock));
        }

        [Test]
        public void TestDateStartAnticipationOk()
        {
            var anticipation = _anticipationService.Start(new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6"));
            Assert.NotNull(anticipation.AnalysisStartDate);
            Assert.AreEqual(DateTime.Now.Date, anticipation.AnalysisStartDate.Value.Date);
        }

        [Test]
        public void TestDateEndPartiallyApprovedAnticipationOk()
        {
            var anticipationService =
                new AnticipationService(new AnticipationMock(statusAnticipations: StatusAnticipations.InAnalysis));
            var anticipation = anticipationService.Finish(new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6"),
                new[]
                {
                    new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6")
                });
            Assert.NotNull(anticipation.AnalysisEndDate);
            Assert.AreEqual(DateTime.Now.Date, anticipation.AnalysisEndDate.Value.Date);
            Assert.AreEqual(ResultAnalysisEnum.PartiallyApproved, anticipation.ResultAnalysis);
        }

        [Test]
        public void TestDateEndApprovedAnticipationOk()
        {
            var anticipationService =
                new AnticipationService(new AnticipationMock(statusAnticipations: StatusAnticipations.InAnalysis));
            var anticipation = anticipationService.Finish(new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6"),
                new[]
                {
                    new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6"),
                    new Guid("E2DB4B89-EF82-49A1-5439-08D87502610B")
                });
            Assert.NotNull(anticipation.AnalysisEndDate);
            Assert.AreEqual(DateTime.Now.Date, anticipation.AnalysisEndDate.Value.Date);
            Assert.AreEqual(ResultAnalysisEnum.Approved, anticipation.ResultAnalysis);
        }

        [Test]
        public void TestDateEndApprovedAnticipationNotOk()
        {
            var anticipationService =
                new AnticipationService(new AnticipationMock(statusAnticipations: StatusAnticipations.InAnalysis));
            Assert.Throws<ForbiddenException>(() =>
            {
                anticipationService.Finish(new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6"),
                    new[]
                    {
                        new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6"),
                        new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6"),
                        new Guid("E2DB4B89-EF82-49A1-5439-08D87502610B")
                    });
            });
        }

        [Test]
        public void TestDateEndReprovedAnticipationOk()
        {
            var anticipationService =
                new AnticipationService(new AnticipationMock(statusAnticipations: StatusAnticipations.InAnalysis));
            var anticipation = anticipationService.Finish(new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6"),
                new[] {new Guid("B6DD6D1A-33F6-411D-736C-08D8750151BD")});
            Assert.NotNull(anticipation.AnalysisEndDate);
            Assert.AreEqual(DateTime.Now.Date, anticipation.AnalysisEndDate.Value.Date);
            Assert.AreEqual(ResultAnalysisEnum.Reproved, anticipation.ResultAnalysis);
        }

        [Test]
        public void TestDateStartAnticipationNotOk()
        {
            var anticipationService =
                new AnticipationService(new AnticipationMock(statusAnticipations: StatusAnticipations.InAnalysis));
            Assert.Throws<ForbiddenException>(() =>
                anticipationService.Start(new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6")));
        }

        [Test]
        public void TestTaxApprovedAnticipationNotOk()
        {
            var anticipationService =
                new AnticipationService(new AnticipationMock(statusAnticipations: StatusAnticipations.InAnalysis));
            var anticipation = anticipationService.Finish(new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6"),
                new[]
                {
                    new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6"),
                    new Guid("E2DB4B89-EF82-49A1-5439-08D87502610B")
                });
            Assert.NotNull(anticipation.AnalysisEndDate);
            Assert.AreEqual(DateTime.Now.Date, anticipation.AnalysisEndDate.Value.Date);
            Assert.AreEqual(ResultAnalysisEnum.Approved, anticipation.ResultAnalysis);
            var anticipationTotal = anticipation.Transactions.Sum(t => t.Installments.Sum(i => i.AnticipationValue));
            var total =
                anticipation.Transactions.Sum(t =>
                    t.Installments.Sum(i => i.NetValue - i.NetValue / 100 * (decimal) 3.8));
            Assert.AreEqual(anticipationTotal, total);
            Assert.AreEqual(anticipation.AnticipatedAmount, total);
        }

        [Test]
        public void TestApprovedAnticipationDateInstallmentOk()
        {
            var anticipationService =
                new AnticipationService(new AnticipationMock(statusAnticipations: StatusAnticipations.InAnalysis));
            var anticipation = anticipationService.Finish(new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6"),
                new[]
                {
                    new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6"),
                    new Guid("E2DB4B89-EF82-49A1-5439-08D87502610B")
                });
            Assert.NotNull(anticipation.AnalysisEndDate);
            Assert.AreEqual(DateTime.Now.Date, anticipation.AnalysisEndDate.Value.Date);
            Assert.AreEqual(ResultAnalysisEnum.Approved, anticipation.ResultAnalysis);
            foreach (var transaction in anticipation.Transactions)
            {
                Assert.True(transaction.Anticipation);
                foreach (var installment in transaction.Installments)
                {
                    Assert.NotNull(installment.TransferDate);
                    Assert.AreEqual(DateTime.Now.Date,installment.TransferDate.Value.Date);
                }
            }
            
        }
    }
}