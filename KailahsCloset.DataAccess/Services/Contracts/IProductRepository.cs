using KailahsCloset.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KailahsCloset.DataAccess.Services.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        void Save();
        void Update(Product product);
    }
}
