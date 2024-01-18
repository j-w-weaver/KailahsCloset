using KailahsCloset.DataAccess.Data;
using KailahsCloset.DataAccess.Services.Contracts;
using KailahsCloset.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KailahsCloset.DataAccess.Services
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _db;
        public ProductRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product product)
        {
            var productFromDb = _db.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (productFromDb != null)
            {
                productFromDb.Brand = product.Brand;
                productFromDb.Name = product.Name;
                productFromDb.Description = product.Description;
                productFromDb.Price = product.Price;
                productFromDb.Category = product.Category;
                productFromDb.Size = product.Size;
                productFromDb.CategoryId = product.CategoryId;
                if (product.ImageURL != null)
                {
                    productFromDb.ImageURL = product.ImageURL;
                }
            }
            //_db.Products.Update(product);
        }
    }
}
