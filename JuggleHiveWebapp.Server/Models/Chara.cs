namespace JuggleHiveWebapp.Server.Models;

public partial class Chara
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long InfoId { get; set; }

    public int Age { get; set; }

    public string Name { get; set; } = null!;

    public long RegionId { get; set; }

    public long RaceId { get; set; }

    public long LvlUpStatId { get; set; }

    public virtual ICollection<CharacterClass> CharacterClasses { get; set; } = [];

    public virtual ICollection<CharacterSkill> CharacterSkills { get; set; } = [];

    public virtual ICollection<CharactersTreePoint> CharactersTreePoints { get; set; } = [];

    public virtual CharacterInfo Info { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = [];

    public virtual BaseStat LvlUpStat { get; set; } = null!;

    public virtual Race Race { get; set; } = null!;

    public virtual Region Region { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}