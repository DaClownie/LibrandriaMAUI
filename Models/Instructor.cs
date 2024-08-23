using System;
using System.Collections.Generic;

namespace LibrandriaMAUI.Models;

public partial class Instructor
{
    public Guid Id { get; set; }

    public string InstructorName { get; set; } = null!;

    public string InstructorPhone { get; set; } = null!;

    public string InstructorEmail { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }
}
