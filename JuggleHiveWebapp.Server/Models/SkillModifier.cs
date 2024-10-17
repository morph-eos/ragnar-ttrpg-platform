using System;
using System.Collections.Generic;

namespace JuggleHiveWebapp.Server.Models;

public partial class SkillModifier
{
    public long Id { get; set; }

    public long SkillId { get; set; }

    public short IsMalus { get; set; }

    public short IsArea { get; set; }

    public int TargetNum { get; set; }

    public string TargetType { get; set; } = null!;

    public string? StatTarget { get; set; }

    public int? StatFlat { get; set; }

    public string? StatScaling { get; set; }

    public int? StatMaxScaling { get; set; }

    public string? StatType { get; set; }

    public virtual Skill Skill { get; set; } = null!;

    public virtual ICollection<SkillModifierDix> SkillModifierDices { get; set; } = new List<SkillModifierDix>();
}
