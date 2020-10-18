using System;
using System.Linq;
using DesafioPagCerto.Entities;
using DesafioPagCerto.Repository.EntityFramework.Drive;
using DesafioPagCerto.Repository.Interfaces;
using TransactionModel = DesafioPagCerto.Repository.EntityFramework.Models.Transaction;
using InstallmentModel = DesafioPagCerto.Repository.EntityFramework.Models.Installment;

namespace DesafioPagCerto.Repository
{
    public class TransactionEntity : ITransactionRepository
    {
        public int Save(Transaction transaction)
        {
            using var drive = new Drive();
            var model = ToModel(transaction);
            drive.Transaction.Add(model);
            drive.SaveChanges();
            return model.Id;
        }

        private static TransactionModel ToModel(Transaction transaction)
        {
            return new TransactionModel()
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
    }
}