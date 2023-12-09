using KailahsCloset_Razor.Data;
using KailahsCloset_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KailahsCloset_Razor.Pages.Type
{
    public class CreateModel : PageModel
    {
        private readonly RazorDbContext _db;
        public Types Types { get; set; }
        public CreateModel(RazorDbContext db)
        {
            _db = db;
        }
        public void OnGet(Types type)
        {
            var types = _db.Types.ToList();
            types.Add(type);
            _db.SaveChanges();
        }
    }
}
