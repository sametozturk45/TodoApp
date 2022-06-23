using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.DataAccessLayer.Abstract
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T GetItem(int? id);
        void Add(T item);
        void Delete(T item);
        void Update(T item);
    }
}
