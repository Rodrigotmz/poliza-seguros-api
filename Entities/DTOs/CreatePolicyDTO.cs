using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CreatePolicyDTO
    {
        public long Id { get; set; }

        public string? PolicyNumber { get; set; } = null!;

        public long PolicyTypeId { get; set; }

        public long ClientId { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public decimal PremiumAmount { get; set; }

        public string Status { get; set; } = null!;
        public CreateClientDTO? Client { get; set; }
    }
}
