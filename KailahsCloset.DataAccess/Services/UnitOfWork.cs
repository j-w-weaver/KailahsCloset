using KailahsCloset.DataAccess.Data;
using KailahsCloset.DataAccess.Services.Contracts;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KailahsCloset.DataAccess.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        //public ICategoryRepository Category 

        public ICategoryRepository CategoryRepository { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
