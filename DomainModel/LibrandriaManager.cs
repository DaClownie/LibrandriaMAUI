using LibrandriaMAUI.Context;
using LibrandriaMAUI.Data;
using LibrandriaMAUI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrandriaMAUI.DomainModel;

public class LibrandriaManager
{
    private LibrandriaDbContext _libContext;
    
    public LibrandriaManager(LibrandriaDbContext context)
    {
        _libContext = context;
    }
    
    // Term Functionality
    private async Task<List<Term>> LoadTermList()
    {
        return await _libContext.Terms
            .Where(t => t.UserId == DataObjects.CurrentUser).ToListAsync();
    }

    private async Task<string> GetTermInfo(string termId)
    {
        var termList = await LoadTermList();
        return termList.Find(t => t.IdText == termId).IdText;
    }

    // Course Functionality
    private async Task<List<Course>> LoadCourseList(string termId)
    {
        return await _libContext.Courses
            .Where(c => c.TermId == termId).ToListAsync();
    }
    
}