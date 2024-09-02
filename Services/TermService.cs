using LibrandriaMAUI.Context;
using LibrandriaMAUI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrandriaMAUI.Services;

public class TermService(LibrandriaDbContext context, UserService userService)
{
    public Term? CurrentTerm { get; set; }
    public async Task<List<Term>> GetTermList()
    {
        var list =  await context.Terms
            .Where(t => t.UserId == userService.CurrentUser!.IdText)
            .ToListAsync();
        list.Sort((a, b) => a.StartDate.CompareTo(b.StartDate));
        return list;
    }

    private async Task GetTerm(string termId)
    {
        CurrentTerm = (await GetTermList())
            .Find(t => t.IdText == termId);
        //TODO Clean up null possibility so warnings are happy
    }

    public async Task AddTerm(Term term)
    {
        await context.Terms.AddAsync(term);
        await context.SaveChangesAsync();
    }

    public async Task DeleteTerm(Term term)
    {
        context.Terms.Remove(term);
        await context.SaveChangesAsync();
    }
}