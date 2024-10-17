using System;
using System.Collections.Generic;

namespace JuggleHiveWebapp.Server.Models;

public partial class News
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? Summary { get; set; }

    public string? Link { get; set; }

    public DateTime Date { get; set; }

    public int FlImportant { get; set; }
}
