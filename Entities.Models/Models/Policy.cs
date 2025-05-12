using System;
using System.Collections.Generic;

namespace Data;

public partial class Policy
{
    public long Id { get; set; }

    public string PolicyNumber { get; set; } = null!;

    public long PolicyTypeId { get; set; }

    public long ClientId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal PremiumAmount { get; set; }

    public string Status { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;

    public virtual PolicyType PolicyType { get; set; } = null!;
}
