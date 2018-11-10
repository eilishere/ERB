using ResumeBank.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private RBDbContext _context;

        public Repository(RBDbContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            //return _context.Set<T>().Where(x => x.Id == id).FirstOrDefault();
            return _context.Set<T>().Find(id);
        }

        public void DeleteById(int id)
        {
            T item = GetById(id);
            DeleteByItem(item);
        }

        public void DeleteByItem(T item)
        {
            item.Status = 0;
        }

        public void DeleteFromDatabaseById(int id)
        {
            var item = GetById(id);
            DeleteFromDatabaseByItem(item);
        }

        public void DeleteFromDatabaseByItem(T item)
        {
            _context.Set<T>().Remove(item);
        }        
    }
}
