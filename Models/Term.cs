using System;
using System.Collections.Generic;

namespace LibrandriaMAUI.Models;

public partial class Term
{
    
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required DateTime StartDate { get; set; }

    public required DateTimeOffset EndDate { get; set; }

    public string UserId { get; set; }

    public string? IdText { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    private Term() { }

    public Term(string name, DateTime startDate, DateTime endDate,
        string userId)
    {
        Id = Guid.NewGuid();
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        UserId = userId;
        IdText = Id.ToString();
    }
}
