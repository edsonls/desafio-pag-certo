using System;
using System.Collections.Generic;
using System.Linq;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Repository.EntityFramework.Drive;
using DesafioPagCerto.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using TransactionModel = DesafioPagCerto.Repository.EntityFramework.Models.Transaction;
using InstallmentModel = DesafioPagCerto.Repository.EntityFramework.Models.Installment;

namespace DesafioPagCerto.Repository
{
    public class TransactionEntity : ITransactionRepository
    {
        private readonly Drive _drive = new Drive();

        public Guid Save(Transaction transaction)
        {
            var model = ToModel(transaction);
            _drive.Transaction.Add(model);
            _drive.SaveChanges();
            return model.NSU;
        }

        public Transaction Find(Guid NSU)
        {
            return ToEntity(_drive.Transaction
                .Where(t => t.NSU == NSU)
                .Include(transaction => transaction.Installments)
                .FirstOrDefault());
        }

        private Transaction ToEntity(TransactionModel transactionModel)
        {
            return transactionModel.Installments != null && transactionModel.Installments.Any()
                ? new Transaction(transactionModel.NSU,
                    transactionModel.TransactionDate,
                    transactionModel.ApprovedDate,
                    transactionModel.ReprovedDate,
                    transactionModel.StatusAnticipation,
                    transactionModel.Confirmation,
                    transactionModel.GrossValue,
                    transactionModel.NetValue,
                    transactionModel.FixedTax,
                    transactionModel.NumberParcel,
                    transactionModel.CreditCardSuffix,
                    transactionModel.Installments.Select(ToEntity()).ToList())
                : new Transaction(transactionModel.NSU,
                    transactionModel.TransactionDate,
                    transactionModel.ApprovedDate,
                    transactionModel.ReprovedDate,
                    transactionModel.StatusAnticipation,
                    transactionModel.Confirmation,
                    transactionModel.GrossValue,
                    transactionModel.NetValue,
                    transactionModel.FixedTax,
                    transactionModel.NumberParcel,
                    transactionModel.CreditCardSuffix);
        }

        private static TransactionModel ToModel(Transaction transaction)
        {
            return transaction.Installments != null && transaction.Installments.Any()
                ? new TransactionModel
                {
                    StatusAnticipation = transaction.Anticipation,
                    Confirmation = transaction.Confirmation,
                    ApprovedDate = transaction.ApprovedDate,
                    FixedTax = transaction.FixedTax,
                    GrossValue = transaction.GrossValue,
                    NetValue = transaction.NetValue,
                    NumberParcel = transaction.NumberParcel,
                    ReprovedDate = transaction.ReprovedDate,
                    TransactionDate = transaction.TransactionDate,
                    CreditCardSuffix = transaction.CreditCardSuffix,
                    Installments = transaction.Installments.Select(ToModel()).ToList()
                }
                : new TransactionModel
                {
                    StatusAnticipation = transaction.Anticipation,
                    Confirmation = transaction.Confirmation,
                    ApprovedDate = transaction.ApprovedDate,
                    FixedTax = transaction.FixedTax,
                    GrossValue = transaction.GrossValue,
                    NetValue = transaction.NetValue,
                    NumberParcel = transaction.NumberParcel,
                    ReprovedDate = transaction.ReprovedDate,
                    TransactionDate = transaction.TransactionDate,
                    CreditCardSuffix = transaction.CreditCardSuffix
                };
        }

        private static Func<Installment, InstallmentModel> ToModel()
        {
            return installment => new InstallmentModel()
            {
                AnticipationValue = installment.AnticipationValue,
                ExpectedDate = installment.ExpectedDate,
                GrossValue = installment.GrossValue,
                NetValue = installment.NetValue,
                NumberParcel = installment.NumberParcel,
                TransferDate = installment.TransferDate,
            };
        }

        private static Func<InstallmentModel, Installment> ToEntity()
        {
            return installment => new Installment(
                installment.Id,
                installment.NumberParcel,
                installment.GrossValue,
                installment.NetValue,
                installment.AnticipationValue,
                installment.ExpectedDate,
                installment.TransferDate,
                installment.Transaction.NSU
            );
        }

        public IEnumerable<Transaction> FindAvailable()
        {
            return _drive.Transaction
                .Where(t => !t.StatusAnticipation && t.Confirmation)
                .Include(transaction => transaction.Installments)
                .ToList().Select(ToEntity);
        }

        public bool Exist(Guid nsu)
        {
            return _drive.Transaction.Any(t => t.NSU == nsu);
        }
    }
}