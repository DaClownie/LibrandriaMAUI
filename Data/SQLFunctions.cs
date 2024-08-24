using LibrandriaMAUI.Context;
using LibrandriaMAUI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrandriaMAUI.Data;

public class SQLFunctions
{
    public static string? CurrentUser { get; set; }
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
            CurrentUser = context.Users
                .Where(u => u.Username == username && u.Password == password)
                .Select(u => u.IdText).FirstOrDefault();
        }
    }
}