using System;
using System.Collections.Generic;

namespace JuggleHiveWebapp.Server.Models;

public partial class TreeEntity
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<CharactersTreePoint> CharactersTreePoints { get; set; } = new List<CharactersTreePoint>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<RaceSkill> RaceSkills { get; set; } = new List<RaceSkill>();

    public virtual ICollection<TreeSkill> TreeSkills { get; set; } = new List<TreeSkill>();
}
