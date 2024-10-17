using System;
using System.Collections.Generic;

namespace JuggleHiveWebapp.Server.Models;

public partial class SkillModifierDix
{
    public long Id { get; set; }

    public int Times { get; set; }

    public int Faces { get; set; }

    public long? SkillModifierId { get; set; }

    public virtual SkillModifier? SkillModifier { get; set; }
}
