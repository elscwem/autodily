using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_shopAutodily.Data;
using E_shopAutodily.Models;
using System.Security.Cryptography;
using System.Text;

namespace E_shopAutodily.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public User User { get; set; } = new User();

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public RegisterModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Zkontrolujeme, zda už e-mail není použit
            if (_context.Users.Any(u => u.Email == User.Email))
            {
                ModelState.AddModelError(string.Empty, "Tento e-mail je již registrován.");
                return Page();
            }

            // Zahashujeme heslo a uložíme do PasswordHash
            User.PasswordHash = ComputeSha256Hash(Password);

            _context.Users.Add(User);
            _context.SaveChanges();

            ViewData["Message"] = "Registrace byla úspěšná!";
            ModelState.Clear();
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
