using System;
using System.Collections.Generic;

namespace Data;

public partial class PolicyType
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();
}
