namespace JuggleHiveWebapp.Server.Models;

public partial class SkillFamily
{
    public long Id { get; set; }

    public virtual ICollection<Skill> Skills { get; set; } = [];

    public virtual ICollection<TreeSkill> TreeSkillParentSkillFamilies { get; set; } = [];

    public virtual ICollection<TreeSkill> TreeSkillSkillFamilies { get; set; } = [];
}
