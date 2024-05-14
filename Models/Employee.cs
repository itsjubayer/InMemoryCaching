using System;
using System.Collections.Generic;

namespace InMemoryCaching.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? Action { get; set; }
}
