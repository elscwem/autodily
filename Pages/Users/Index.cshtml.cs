using E_shopAutodily.Data;
using E_shopAutodily.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_shopAutodily.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<User> Users { get; set; }

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Users = _context.Users.ToList();
        }
    }
}
