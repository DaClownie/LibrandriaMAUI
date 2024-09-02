using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrandriaMAUI.Models;

public partial class Term
{
    
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required DateTime StartDate { get; set; }

    public required DateTime EndDate { get; set; }

    public string UserId { get; set; }

    public string? IdText { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

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

    public new string ToString()
    {
        return $"{StartDate:dd/MM/yyyy} - {EndDate:dd/MM/yyyy}";
    }
}
