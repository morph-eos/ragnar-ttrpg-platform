using System;
using System.Collections.Generic;

namespace JuggleHiveWebapp.Server.Models;

public partial class AllowedItem
{
    public long Id { get; set; }

    public long ClassId { get; set; }

    public string ItemType { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;
}
