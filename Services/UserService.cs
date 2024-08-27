using LibrandriaMAUI.Context;
using LibrandriaMAUI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrandriaMAUI.Services;

public class UserService(LibrandriaDbContext context)
{
    public User? CurrentUser { get; set; }
    
    public async Task AddUser(string username, string password, string email)
    {
        var user = new User(username, password, email);
        context.Users.Add(user);
        await context.SaveChangesAsync();
        
        //TODO needs verification logic/error handling (user already exists, etc.)
    }

    public async Task GetUser(string username, string password)
    {
        CurrentUser  = await context.Users
            .Where(u => u.Username == username && u.Password == password)
            .FirstOrDefaultAsync();
    }
}