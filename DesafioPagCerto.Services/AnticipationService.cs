using System;
using System.Collections.Generic;
using System.Linq;
using DesafioPagCerto.Entities.Anticipations;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Repository.Interfaces;
using DesafioPagCerto.Services.Interfaces;

namespace DesafioPagCerto.Services
{
    public class AnticipationService : IAnticipationService
    {
        private const decimal TaxFixed = (decimal) 0.90;
        private readonly IAnticipationRepository _repository;

        public AnticipationService(IAnticipationRepository repository)
        {
            _repository = repository;
        }

        public Guid CreateAnticipation(IEnumerable<Transaction> transactions)
        {
            if (AnticipationInOpen())
            {
                throw new Exception("Já existe uma antecipação em aberto");
            }

            var enumerable = transactions.ToList();
            var anticipation = new Anticipation(DateTime.Now,
                enumerable.Sum(t => t.NetValue),
                enumerable.ToList());
            return _repository.Save(anticipation);
        }

        public bool AnticipationInOpen()
        {
            return _repository.AnticipationInOpen();
        }
    }
}