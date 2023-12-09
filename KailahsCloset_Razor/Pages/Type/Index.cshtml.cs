using KailahsCloset_Razor.Data;
using KailahsCloset_Razor.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KailahsCloset_Razor.Pages.Type
{
    public class IndexModel : PageModel
    {
        private readonly RazorDbContext _db;
        public List<Types> TypesList { get; set; }
        public IndexModel(RazorDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
             TypesList = _db.Types.ToList();
        }

    }
}
