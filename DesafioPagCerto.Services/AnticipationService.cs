using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}