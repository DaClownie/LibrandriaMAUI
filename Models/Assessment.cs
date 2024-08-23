using System;
using System.Collections.Generic;

namespace LibrandriaMAUI.Models;

public partial class Assessment
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Type { get; set; }

    public Guid CourseId { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public sbyte? NotificationStart { get; set; }

    public sbyte? NotificationEnd { get; set; }

    public string? IdText { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }
}
