using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioPagCerto.Requests
{
    public class AnticipationRequest
    {
        [Required]
        public Guid nsu { get; set; }
    }
}