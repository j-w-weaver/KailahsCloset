using KailahsCloset.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KailahsCloset.DataAccess.Services.Contracts
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Save();
        void Update(Category category);
    }
}
