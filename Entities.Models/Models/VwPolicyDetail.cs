using System;
using System.Collections.Generic;

namespace Data;

public partial class VwPolicyDetail
{
    public long ClientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastNameMaternal { get; set; }

    public string? LastNamePaternal { get; set; }

    public int Age { get; set; }

    public string? Curp { get; set; }

    public string Gender { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public long? CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public string PolicyNumber { get; set; } = null!;

    public long PolicyId { get; set; }

    public long PolicyTypeId { get; set; }

    public string PolicyTypeName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal PremiumAmount { get; set; }

    public string Status { get; set; } = null!;
}
