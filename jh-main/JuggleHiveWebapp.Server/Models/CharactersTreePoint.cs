namespace JuggleHiveWebapp.Server.Models;

public partial class CharactersTreePoint
{
    public long Id { get; set; }

    public long CharacterId { get; set; }

    public long TreeId { get; set; }

    public int? AvailablePoints { get; set; }

    public virtual Chara Character { get; set; } = null!;

    public virtual TreeEntity Tree { get; set; } = null!;
}
