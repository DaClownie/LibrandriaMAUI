using LibrandriaMAUI.Context;
using LibrandriaMAUI.Models;

namespace LibrandriaMAUI.Services;

public class LibDbService(LibrandriaDbContext context)
{
    public Term? CurrentTerm { get; set; }
    public async Task AddTerm(string name, DateTime startDate, DateTime endDate,
        string userId)
    {
        var term = new Term(name, startDate, endDate, userId)
        {
            Name = name,
            StartDate = startDate,
            EndDate = endDate,
            UserId = userId
        };
        context.Terms.Add(term);
        await context.SaveChangesAsync();
    }
}