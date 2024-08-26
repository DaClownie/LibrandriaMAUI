using System;
using System.Collections.Generic;

namespace LibrandriaMAUI.Models;

public partial class Course
{
    public Guid Id { get; set; }

    public string TermId { get; set; }
    
    public string UserId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public int Status { get; set; }

    public string InstructorId { get; set; }

    public string? Notes { get; set; }

    public string? ObjectiveAssessmentId { get; set; }

    public string? PerformanceAssessmentId { get; set; }

    public sbyte? NotificationStart { get; set; }

    public sbyte? NotificationEnd { get; set; }

    public string? IdText { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }
}
