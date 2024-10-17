using System;
using System.Collections.Generic;

namespace JuggleHiveWebapp.Server.Models;

public partial class SkillFamily
{
    public long Id { get; set; }

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

    public virtual ICollection<TreeSkill> TreeSkillParentSkillFamilies { get; set; } = new List<TreeSkill>();

    public virtual ICollection<TreeSkill> TreeSkillSkillFamilies { get; set; } = new List<TreeSkill>();
}
