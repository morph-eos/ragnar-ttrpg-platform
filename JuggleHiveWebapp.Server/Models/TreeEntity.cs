namespace JuggleHiveWebapp.Server.Models;

public partial class TreeEntity
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<CharactersTreePoint> CharactersTreePoints { get; set; } = [];

    public virtual ICollection<Class> Classes { get; set; } = [];

    public virtual ICollection<RaceSkill> RaceSkills { get; set; } = [];

    public virtual ICollection<TreeSkill> TreeSkills { get; set; } = [];
}
