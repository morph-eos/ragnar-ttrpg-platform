namespace JuggleHiveWebapp.Server.Models;

public partial class TreeSkill
{
    public long Id { get; set; }

    public long TreeId { get; set; }

    public long SkillFamilyId { get; set; }

    public long? ParentSkillFamilyId { get; set; }

    public virtual SkillFamily? ParentSkillFamily { get; set; }

    public virtual SkillFamily SkillFamily { get; set; } = null!;

    public virtual TreeEntity Tree { get; set; } = null!;
}
