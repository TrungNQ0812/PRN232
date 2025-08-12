using System;
using System.Collections.Generic;

namespace MICHO_data.Models;

public partial class OrderDetailIceCream
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int IceId { get; set; }

    public virtual IceCream Ice { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual OrderDetail OrderDetail { get; set; } = null!;
}
