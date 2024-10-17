using System;
using System.Collections.Generic;

namespace JuggleHiveWebapp.Server.Models;

public partial class Region
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Chara> Charas { get; set; } = new List<Chara>();

    public virtual ICollection<Race> Races { get; set; } = new List<Race>();
}
