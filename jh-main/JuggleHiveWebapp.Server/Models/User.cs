namespace JuggleHiveWebapp.Server.Models;

public partial class User
{
    public long Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Chara> Charas { get; set; } = new List<Chara>();
}
