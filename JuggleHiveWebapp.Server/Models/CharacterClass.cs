using System;
using System.Collections.Generic;

namespace JuggleHiveWebapp.Server.Models;

public partial class CharacterClass
{
    public long Id { get; set; }

    public long CharacterId { get; set; }

    public long ClassId { get; set; }

    public virtual Chara Character { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;
}
