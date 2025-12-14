using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_shopAutodily.Data;
using E_shopAutodily.Models;
using System.Security.Cryptography;
using System.Text;

public class RegisterModel : PageModel
{
    private readonly AppDbContext _db;

    public RegisterModel(AppDbContext db)
    {
        _db = db;
    }

    [BindProperty] public string Username { get; set; } = "";
    [BindProperty] public string Email { get; set; } = "";
    [BindProperty] public string Password { get; set; } = "";

    public string Message { get; set; } = "";

    public IActionResult OnPost()
    {
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(Password));
        var passwordHash = Convert.ToHexString(hash);

        var user = new User
        {
            Username = Username,
            Email = Email,
            PasswordHash = passwordHash
        };

        _db.Users.Add(user);
        _db.SaveChanges();

        Message = "Registrace úspěšná";
        return Page();
    }
}
