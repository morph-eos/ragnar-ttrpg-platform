using System;
using System.Collections.Generic;

namespace JuggleHiveWebapp.Server.Models;

public partial class CharacterSkill
{
    public long Id { get; set; }

    public long CharacterId { get; set; }

    public int TotalUses { get; set; }

    public int? Status { get; set; }

    public long? UnlockedSkillId { get; set; }

    public int? TempUses { get; set; }

    public virtual Chara Character { get; set; } = null!;

    public virtual Skill? UnlockedSkill { get; set; }
}
