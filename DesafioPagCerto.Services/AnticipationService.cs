using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using DesafioPagCerto.Entities.Anticipations;
using DesafioPagCerto.Entities.Transactions;
using DesafioPagCerto.Enum;
using DesafioPagCerto.Repository.Interfaces;
using DesafioPagCerto.Services.Interfaces;

namespace DesafioPagCerto.Services
{
    public class AnticipationService : IAnticipationService
    {
        private const decimal TaxFixed = (decimal) 3.8;
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

        public Anticipation Start(Guid anticipationId)
        {
            var anticipation = Find(anticipationId);
            if (anticipation.StatusAnticipation != StatusAnticipations.Pending)
            {
                throw new HttpRequestException("O status da antecipação precisa ser pendente!");
            }

            anticipation.Start();
            if (!_repository.Edit(anticipation))
            {
                throw new HttpRequestException("Erro!");
            }

            return anticipation;
        }

        public Anticipation Finish(Guid anticipationId, IEnumerable<Guid> transactionsApproved)
        {
            var anticipation = _repository.Find(anticipationId);
            return anticipation.Approved(transactionsApproved, TaxFixed).Count == 0
                ? _repository.Reproved(anticipation)
                : _repository.Approved(anticipation);
        }

        private Anticipation Find(Guid id)
        {
            return _repository.Find(id);
        }

        public bool AnticipationInOpen()
        {
            return _repository.AnticipationInOpen();
        }

        public IEnumerable<Anticipation> ListAll(ResultAnalysisEnum? status)
        {
            return _repository.ListAll(status);
        }
    }
}