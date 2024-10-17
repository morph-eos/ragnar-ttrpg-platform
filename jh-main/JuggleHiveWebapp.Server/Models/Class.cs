using System;
using System.Collections.Generic;

namespace JuggleHiveWebapp.Server.Models;

public partial class Class
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public long TreeId { get; set; }

    public long StatsId { get; set; }

    public virtual ICollection<AllowedItem> AllowedItems { get; set; } = new List<AllowedItem>();

    public virtual ICollection<CharacterClass> CharacterClasses { get; set; } = new List<CharacterClass>();

    public virtual BaseStat Stats { get; set; } = null!;

    public virtual TreeEntity Tree { get; set; } = null!;
}
