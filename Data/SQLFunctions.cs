using LibrandriaMAUI.Context;
using LibrandriaMAUI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrandriaMAUI.Data;

public class SQLFunctions
{
    // User Functions
    public static async Task AddNewUser(string username, string password, string email)
    {
        var user = new User(username, password, email);
        await using (var context = new LibrandriaDbContext())
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }
        //TODO needs verification logic/error handling
    }

    public static async Task GetUserId(string username, string password)
    {
        await using (var context = new LibrandriaDbContext())
        {
            DataObjects.CurrentUser = context.Users
                .Where(u => u.Username == username && u.Password == password)
                .Select(u => u.IdText).FirstOrDefault();
        }
    }
    
    // Terms Functionality
    public static async Task LoadTermList()
    {
        await using (var context = new LibrandriaDbContext())
        {
            DataObjects.TermList.Clear();
            DataObjects.TermList = context.Terms
                .Where(t => t.UserId == DataObjects.CurrentUser).ToList();
        }
    }
    
    public static async Task GetTermInfo(string termId)
    {
        await LoadTermList();
        var term = DataObjects.TermList
            .Find(t => t.IdText == termId);
        DataObjects.CurrentTerm = term.IdText;
        //TODO Possibly need to handle null?
    }
    
    // Course Functionality
    public static async Task<List<Course>> LoadCourseList(string termId)
    {
        await using var context = new LibrandriaDbContext();
        return await context.Courses
            .Where(c => c.TermId == termId).ToListAsync();
    }
}