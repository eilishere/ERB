using ResumeBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Repository
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T item);
        void AddRange(ICollection<T> items);
        void Update(T item);
        void UpdateRange(ICollection<T> items);

        ICollection<T> GetAll();

        T GetById(int id);

        void DeleteById(int id);
        void DeleteRangeById(ICollection<int> ids);

        void DeleteByItem(T item);
        void DeleteRangeByItem(ICollection<T> items);
        void DeleteFromDatabaseById(int id);
        void DeleteFromDatabaseByItem(T item);
        void DeleteRangeFromDatabaseByIds(ICollection<int> ids);
        void DeleteRangeFromDatabaseByItems(ICollection<T> items);
    }
}
