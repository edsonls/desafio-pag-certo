using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioPagCerto.Requests
{
    public class AnticipationRequest
    {
        [Required]
        [StringLength(maximumLength: 36, MinimumLength = 36)]
        public Guid nsu { get; set; }
    }
}