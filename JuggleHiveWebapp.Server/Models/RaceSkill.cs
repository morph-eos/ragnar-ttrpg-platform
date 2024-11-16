namespace JuggleHiveWebapp.Server.Models;

public partial class RaceSkill
{
    public long Id { get; set; }

    public long? RaceId { get; set; }

    public long? SkillTreeId { get; set; }

    public int? Slot { get; set; }

    public virtual Race? Race { get; set; }

    public virtual TreeEntity? SkillTree { get; set; }
}
