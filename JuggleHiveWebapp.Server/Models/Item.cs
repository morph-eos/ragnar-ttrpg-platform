using System;
using System.Collections.Generic;

namespace JuggleHiveWebapp.Server.Models;

public partial class Item
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;

    public double Weight { get; set; }

    public bool Stackable { get; set; }

    public long? MainSkillId { get; set; }

    public virtual Skill? MainSkill { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
