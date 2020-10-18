using System;
using System.Linq;
using DesafioPagCerto.Entities;
using DesafioPagCerto.Repository.EntityFramework.Drive;
using DesafioPagCerto.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using TransactionModel = DesafioPagCerto.Repository.EntityFramework.Models.Transaction;
using InstallmentModel = DesafioPagCerto.Repository.EntityFramework.Models.Installment;

namespace DesafioPagCerto.Repository
{
    public class TransactionEntity : ITransactionRepository
    {
        public Guid Save(Transaction transaction)
        {
            using var drive = new Drive();
            var model = ToModel(transaction);
            drive.Transaction.Add(model);
            drive.SaveChanges();
            return model.NSU;
        }

        public Transaction find(Guid NSU)
        {
            using var drive = new Drive();
            return ToEntity(drive.Transaction
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
                    transactionModel.Anticipation,
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
                    transactionModel.Anticipation,
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
                    Anticipation = transaction.Anticipation,
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
                    Anticipation = transaction.Anticipation,
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
    }
}