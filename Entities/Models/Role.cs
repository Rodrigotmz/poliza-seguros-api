using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Role
{
    public long Id { get; set; }

    public string NameRol { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
