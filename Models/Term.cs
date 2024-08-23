using System;
using System.Collections.Generic;

namespace LibrandriaMAUI.Models;

public partial class Term
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Guid StudentId { get; set; }

    public string? IdText { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }
}
