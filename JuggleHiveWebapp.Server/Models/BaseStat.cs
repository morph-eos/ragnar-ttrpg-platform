namespace JuggleHiveWebapp.Server.Models;

public partial class BaseStat
{
    public long Id { get; set; }

    public int? Vitality { get; set; }

    public int? Strength { get; set; }

    public int? Dexterity { get; set; }

    public int? Arcane { get; set; }

    public int? Instinct { get; set; }

    public int? Charisma { get; set; }

    public int? Speed { get; set; }

    public virtual ICollection<Chara> Charas { get; set; } = new List<Chara>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Race> Races { get; set; } = new List<Race>();
}
