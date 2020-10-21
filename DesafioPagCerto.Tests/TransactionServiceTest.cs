using System;
using System.Linq;
using DesafioPagCerto.Exception;
using DesafioPagCerto.Repository.Tests;
using DesafioPagCerto.Services;
using DesafioPagCerto.Services.Interfaces;
using NUnit.Framework;

namespace DesafioPagCerto.Tests
{
    public class TransactionServiceTest
    {
        private readonly ITransactionService _transactionService = new TransactionService(new TransactionMock());

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTransactionTaxOk()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 1000);
            Assert.True(tra.Confirmation);
            Assert.AreEqual(0.90, tra.GrossValue - tra.NetValue);
        }

        [Test]
        public void TestTransactionTaxNotOk()
        {
            var tra = _transactionService.CreateTransaction("5999999999999999", 2, 1000);
            Assert.False(tra.Confirmation);
            Assert.AreEqual(tra.GrossValue, tra.NetValue);
        }

        [Test]
        public void TestCreateTransactionNumberCardOk()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 1000);
            Assert.True(tra.Confirmation);
        }

        [Test]
        public void TestCreateTransactionNumberCardNotOk()
        {
            var tra = _transactionService.CreateTransaction("5999999999999999", 2, 1000);
            Assert.False(tra.Confirmation);
        }

        [Test]
        public void TestCreateTransactionNumberCardLenghtOk()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 1000);
            Assert.True(tra.Confirmation);
        }

        [Test]
        public void TestCreateTransactionNumberCardLenghtMinorNotOk()
        {
            var tra = _transactionService.CreateTransaction("59099999999999", 2, 1000);
            Assert.False(tra.Confirmation);
        }

        [Test]
        public void TestCreateTransactionNumberCardLenghtLargerNotOk()
        {
            var tra = _transactionService.CreateTransaction("59099999999997999", 2, 1000);
            Assert.False(tra.Confirmation);
        }

        [Test]
        public void TestCreateTransactionConfirmationOk()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 1000);
            Assert.True(tra.Confirmation);
        }

        [Test]
        public void TestCreateTransactionConfirmationNotOk()
        {
            var tra = _transactionService.CreateTransaction("5999999999999999", 2, 1000);
            Assert.False(tra.Confirmation);
        }

        [Test]
        public void TestCreateInstallmentsOk()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 1000);
            Assert.True(tra.Confirmation);
            Assert.AreEqual(2, tra.Installments.Count());
        }

        [Test]
        public void TestCreateInstallmentsNotOk()
        {
            var tra = _transactionService.CreateTransaction("599999999999999", 2, 1000);
            Assert.False(tra.Confirmation);
            Assert.AreEqual(null, tra.Installments);
        }

        [Test]
        public void TestCreateInstallmentsExpectedDateOk()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 1000);
            Assert.True(tra.Confirmation);
            Assert.AreEqual(DateTime.Now.AddMonths(1).Date, tra.Installments.ToArray()[0].ExpectedDate.Date);
            Assert.AreEqual(DateTime.Now.AddMonths(2).Date, tra.Installments.ToArray()[1].ExpectedDate.Date);
        }

        [Test]
        public void TestCreateTransactionNetValueOk()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 100);
            Assert.True(tra.Confirmation);
            Assert.AreEqual(99.10, tra.NetValue);
        }

        [Test]
        public void TestCreateTransactionNetValueNotOk()
        {
            var tra = _transactionService.CreateTransaction("59099999999999999", 2, 100);
            Assert.False(tra.Confirmation);
            Assert.AreEqual(100, tra.NetValue);
        }

        [Test]
        public void TestCreateInstallmentsNetValueOk()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 100);
            Assert.True(tra.Confirmation);
            Assert.AreEqual(99.10, tra.Installments.Sum(i => i.NetValue));
        }

        [Test]
        public void TestFindTransactionOk()
        {
            var tra = _transactionService.Find(Guid.Empty);
            Assert.AreNotEqual(null, tra);
        }

        [Test]
        public void TestCheckTransactionForAnticipationNotOk()
        {
            Assert.Throws<ForbiddenException>(() =>
                _transactionService.CheckAvailable(new[] {new Guid("D7484DEE-AB6F-488B-08FE-08D8750151B6")}));
        }

        [Test]
        public void TestCheckTransactionForAnticipationOk()
        {
            var tra = _transactionService.CheckAvailable(new[] {new Guid()});
            Assert.AreNotEqual(null, tra);
        }
    }
}