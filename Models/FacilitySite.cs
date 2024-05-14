using System;
using System.Collections.Generic;

namespace InMemoryCaching.Models;

public partial class FacilitySite
{
    public Guid FacilitySiteId { get; set; }

    public string? FacilityName { get; set; }

    public bool IsActive { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public bool IsDeleted { get; set; }
}
