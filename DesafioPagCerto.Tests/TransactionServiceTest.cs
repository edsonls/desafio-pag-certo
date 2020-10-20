using System;
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
    }
}