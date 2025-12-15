using Microsoft.AspNetCore.Mvc.RazorPages;
using E_shopAutodily.Data;
using E_shopAutodily.Models;
using Microsoft.EntityFrameworkCore;

namespace E_shopAutodily.Pages
{
    public class MyOrdersModel : PageModel
    {
        private readonly AppDbContext _db;

        public List<Order> Orders { get; set; } = new();

        public MyOrdersModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            // zobrazeni objednavek
            Orders = _db.Orders
                .Include(o => o.OrderItems)
                .ToList();
        }
    }
}
