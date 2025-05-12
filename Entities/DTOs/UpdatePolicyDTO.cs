using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UpdatePolicyDTO
    {
        public long Id { get; set; }
        public string Status { get; set; } = null!;
    }
}
