using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using E_commerce.DataAccess.Data;
using E_commerce.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> DbSet;
        public Repository(ApplicationDbContext db)
        // We already have the method in program.cs so we just call it 
        {
            _db = db;
            this.DbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);        
        }

        public IEnumerable<T> GetAll()
        {
            // DbSet = _db + (Table name[T]) We send the table name during _productRepo 
            IQueryable<T> query = DbSet;
            return query.ToList();

        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            // FirstOrDefault = to get the one specific info for that item
            IQueryable<T> query = DbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRage(IEnumerable<T> entity)
        {
            DbSet.RemoveRange(entity);
        }
    }
}
