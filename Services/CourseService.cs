using LibrandriaMAUI.Context;
using LibrandriaMAUI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrandriaMAUI.Services;

public class CourseService(LibrandriaDbContext context, TermService termService)
{
    public Course? CurrentCourse { get; set; }

    private async Task<List<Course>> GetCourseList()
    {
        return await context.Courses
            .Where(c => c.TermId == termService.CurrentTerm!.IdText)
            .ToListAsync();
    }
}