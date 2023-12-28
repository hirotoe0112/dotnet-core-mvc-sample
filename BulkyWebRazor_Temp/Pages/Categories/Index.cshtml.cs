using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;

namespace BulkyWebRazor_Temp.Pages_Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IList<Category> Categories { get; set; } = default!;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Categories = _db.Categories.ToList();
        }
    }
}
