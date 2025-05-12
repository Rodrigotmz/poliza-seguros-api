using System;
using System.Collections.Generic;

namespace Data;

public partial class Client
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastNameMaternal { get; set; }

    public string? LastNamePaternal { get; set; }

    public int Age { get; set; }

    public string Gender { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public long? UsersId { get; set; }

    public long? CountryId { get; set; }

    public string? Curp { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();

    public virtual User? Users { get; set; }
}
