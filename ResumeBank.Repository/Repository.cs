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

        public void AddRange(ICollection<T> items)
        {
            _context.Set<T>().AddRange(items);
        }

        public void Update(T item)
        {
            var local = _context.Set<T>().Local.FirstOrDefault(c => c.Id == item.Id);
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(item).State = EntityState.Modified;
        }

        public void UpdateRange(ICollection<T> items)
        {
            foreach (var item in items)
            {
                Update(item);
            }
        }

        public ICollection<T> GetAll()
        {
            return _context.Set<T>().Where(c => c.Status == 1).ToList();
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

        public void DeleteRangeById(ICollection<int> ids)
        {
            foreach (var id in ids)
            {
                DeleteById(id);
            }
        }

        public void DeleteByItem(T item)
        {
            item.Status = 0;
        }

        public void DeleteRangeByItem(ICollection<T> items)
        {
            foreach (var item in items)
            {
                DeleteByItem(item);
            }
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

        public void DeleteRangeFromDatabaseByIds(ICollection<int> ids)
        {
            foreach (var id in ids)
            {
                DeleteFromDatabaseById(id);
            }
        }

        public void DeleteRangeFromDatabaseByItems(ICollection<T> items)
        {
            foreach (var item in items)
            {
                DeleteFromDatabaseByItem(item);
            }
        }
    }
}
