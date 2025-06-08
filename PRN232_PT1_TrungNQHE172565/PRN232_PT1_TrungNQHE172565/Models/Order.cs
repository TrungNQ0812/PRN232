using System;
using System.Collections.Generic;

namespace PRN232_PT1_TrungNQHE172565.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? Status { get; set; }

    public DateOnly? OrderDate { get; set; }

    public int? EmpId { get; set; }

    public virtual Employee? Emp { get; set; }
}
