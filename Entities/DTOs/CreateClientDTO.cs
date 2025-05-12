using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CreateClientDTO
    {
        public long Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string? LastNameMaternal { get; set; }

        public string? LastNamePaternal { get; set; }

        public int Age { get; set; }

        public string? Curp { get; set; }

        public string Gender { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public long? UsersId { get; set; }

        public long? CountryId { get; set; }
    }
}
