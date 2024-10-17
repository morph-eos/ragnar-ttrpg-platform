using System;
using System.Collections.Generic;

namespace JuggleHiveWebapp.Server.Models;

public partial class CharacterInfo
{
    public long Id { get; set; }

    public int? Lvl { get; set; }

    public int? CurrentHp { get; set; }

    public int? Shield { get; set; }

    public int? MaxHp { get; set; }

    public int? CurrentMp { get; set; }

    public int? CurrentKi { get; set; }

    public int? CurrentFury { get; set; }

    public int? CurrentMiracles { get; set; }

    public int? CurrentMetamorphs { get; set; }

    public virtual ICollection<Chara> Charas { get; set; } = new List<Chara>();
}
