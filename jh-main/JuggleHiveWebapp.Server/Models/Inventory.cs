using System;
using System.Collections.Generic;

namespace JuggleHiveWebapp.Server.Models;

public partial class Inventory
{
    public long Id { get; set; }

    public bool Equipped { get; set; }

    public int? Stacks { get; set; }

    public long CharacterId { get; set; }

    public virtual Chara Character { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
