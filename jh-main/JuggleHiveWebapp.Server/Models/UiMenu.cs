using System;
using System.Collections.Generic;

namespace JuggleHiveWebapp.Server.Models;

public partial class UiMenu
{
    public long Id { get; set; }

    public long? OwnerId { get; set; }

    public string Item { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public short IsEnabled { get; set; }

    public int? SiteId { get; set; }

    public int? Order { get; set; }

    public virtual ICollection<UiMenu> InverseOwner { get; set; } = new List<UiMenu>();

    public virtual UiMenu? Owner { get; set; }
}
