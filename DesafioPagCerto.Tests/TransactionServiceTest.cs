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
            if (tra.Confirmation && tra.NetValue == tra.GrossValue - tra.FixedTax)
                Assert.Pass("Ok");
            else
                Assert.Fail("Error");
        }

        [Test]
        public void TestTransactionTaxNotOK()
        {
            var tra = _transactionService.CreateTransaction("5999999999999999", 2, 1000);
            if (!tra.Confirmation && tra.NetValue == tra.GrossValue)
                Assert.Pass("Ok");
            else
                Assert.Fail("Error");
        }

        [Test]
        public void TestCreateTransactionConfirmationOK()
        {
            var re = _transactionService.CreateTransaction("5909999999999999", 2, 1000);
            if (re.Confirmation)
                Assert.Pass("Ok");
            else
                Assert.Fail("Error");
        }

        [Test]
        public void TestCreateTransactionConfirmationNotOK()
        {
            var re = _transactionService.CreateTransaction("5999999999999999", 2, 1000);
            if (!re.Confirmation)
                Assert.Pass("Ok");
            else
                Assert.Fail("Error");
        }
    }
}