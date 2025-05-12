using System;
using System.Collections.Generic;

namespace Data;

public partial class User
{
    public long Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long RolId { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual Role Rol { get; set; } = null!;
}
