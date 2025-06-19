using System;
using System.Collections.Generic;

namespace school_api.Infrastructure.Models;

public partial class Period
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<PeriodsGroup> PeriodsGroups { get; set; } = new List<PeriodsGroup>();
}
