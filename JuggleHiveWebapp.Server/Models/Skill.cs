namespace JuggleHiveWebapp.Server.Models;

public partial class Skill
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int? Cost { get; set; }

    public string? CostType { get; set; }

    public long SkillFamilyId { get; set; }

    public int SkillFamilyRank { get; set; }

    public virtual ICollection<CharacterSkill> CharacterSkills { get; set; } = new List<CharacterSkill>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual SkillFamily SkillFamily { get; set; } = null!;

    public virtual ICollection<SkillModifier> SkillModifiers { get; set; } = new List<SkillModifier>();

    public virtual ICollection<Item> ItemsNavigation { get; set; } = new List<Item>();
}
