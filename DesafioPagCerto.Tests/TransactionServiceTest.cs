using System;
using System.Linq;
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
        public void TestTransactionTaxOK()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 1000);
            Assert.True(tra.Confirmation);
            Assert.AreEqual(0.90, tra.GrossValue - tra.NetValue);
        }

        [Test]
        public void TestTransactionTaxNotOK()
        {
            var tra = _transactionService.CreateTransaction("5999999999999999", 2, 1000);
            Assert.False(tra.Confirmation);
            Assert.AreEqual(tra.GrossValue, tra.NetValue);
        }

        [Test]
        public void TestCreateTransactionNumberCardOK()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 1000);
            Assert.True(tra.Confirmation);
        }

        [Test]
        public void TestCreateTransactionNumberCardNotOK()
        {
            var tra = _transactionService.CreateTransaction("5999999999999999", 2, 1000);
            Assert.False(tra.Confirmation);
        }

        [Test]
        public void TestCreateTransactionNumberCardLenghtOK()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 1000);
            Assert.True(tra.Confirmation);
        }

        [Test]
        public void TestCreateTransactionNumberCardLenghtMinorNotOK()
        {
            var tra = _transactionService.CreateTransaction("59099999999999", 2, 1000);
            Assert.False(tra.Confirmation);
        }

        [Test]
        public void TestCreateTransactionNumberCardLenghtLargerNotOK()
        {
            var tra = _transactionService.CreateTransaction("59099999999997999", 2, 1000);
            Assert.False(tra.Confirmation);
        }

        [Test]
        public void TestCreateTransactionConfirmationOK()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 1000);
            Assert.True(tra.Confirmation);
        }

        [Test]
        public void TestCreateTransactionConfirmationNotOK()
        {
            var tra = _transactionService.CreateTransaction("5999999999999999", 2, 1000);
            Assert.False(tra.Confirmation);
        }

        [Test]
        public void TestCreateInstallmentsOK()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 1000);
            Assert.True(tra.Confirmation);
            Assert.AreEqual(2, tra.Installments.Count());
        }

        [Test]
        public void TestCreateInstallmentsNotOK()
        {
            var tra = _transactionService.CreateTransaction("599999999999999", 2, 1000);
            Assert.False(tra.Confirmation);
            Assert.AreEqual(null, tra.Installments);
        }
        [Test]
        public void TestCreateInstallmentsExpectedDateOK()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 1000);
            Assert.True(tra.Confirmation);
            Assert.AreEqual(DateTime.Now.AddMonths(1).Date, tra.Installments.ToArray()[0].ExpectedDate.Date);
            Assert.AreEqual(DateTime.Now.AddMonths(2).Date, tra.Installments.ToArray()[1].ExpectedDate.Date);
        }
        [Test]
        public void TestCreateTransactionNetValueOK()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 100);
            Assert.True(tra.Confirmation);
            Assert.AreEqual(99.10, tra.NetValue);
        }
        [Test]
        public void TestCreateTransactionNetValueNotOK()
        {
            var tra = _transactionService.CreateTransaction("59099999999999999", 2, 100);
            Assert.False(tra.Confirmation);
            Assert.AreEqual(100, tra.NetValue);
        }
        [Test]
        public void TestCreateInstallmentsNetValueOK()
        {
            var tra = _transactionService.CreateTransaction("5909999999999999", 2, 100);
            Assert.True(tra.Confirmation);
            Assert.AreEqual(99.10, tra.Installments.Sum(i => i.NetValue));
        }
    }
}