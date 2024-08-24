using System;
using System.Collections.Generic;

namespace LibrandriaMAUI.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string? IdText { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    public User(string username, string password, string email)
    {
        Id = Guid.NewGuid();
        Username = username;
        Password = password;
        Email = email;
    }
}
