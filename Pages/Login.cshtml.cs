using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_shopAutodily.Data;
using System.Security.Cryptography;
using System.Text;

namespace E_shopAutodily.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ViewData["Error"] = "Vyplňte všechna pole.";
                return Page();
            }

            // Zahashujeme heslo a ověříme shodu s databází
            string passwordHash = ComputeSha256Hash(Password);
            var user = _context.Users.FirstOrDefault(u => u.Email == Email && u.PasswordHash == passwordHash);

            if (user == null)
            {
                ViewData["Error"] = "Nesprávný e-mail nebo heslo.";
                return Page();
            }

            ViewData["Message"] = $"Vítej zpět, {user.Username}!";
            return Page();
        }

        private static string ComputeSha256Hash(string rawData)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            var sb = new StringBuilder();
            foreach (var b in bytes) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
    }
}
