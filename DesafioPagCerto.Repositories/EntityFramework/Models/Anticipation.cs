using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DesafioPagCerto.Enum;

namespace DesafioPagCerto.Repository.EntityFramework.Models
{
    public class Anticipation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public DateTime SolicitationDate { get; set; }
        public DateTime? AnalysisStartDate { get; set; }
        public DateTime? AnalysisEndDate { get; set; }
        public ResultAnalysisEnum? ResultAnalysis { get; set; }
        public StatusAnticipations StatusAnticipation { get; set; }
        public decimal RequestedAmount { get; set; }
        public decimal AnticipatedAmount { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}