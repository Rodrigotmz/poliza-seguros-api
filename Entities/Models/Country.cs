using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Country
{
    public long CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
