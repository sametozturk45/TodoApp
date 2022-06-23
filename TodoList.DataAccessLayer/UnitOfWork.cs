using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.DataAccessLayer.Concrete;
using TodoList.EntityLayer.Models;

namespace TodoList.DataAccessLayer
{
    public class UnitOfWork : IDisposable
    {
        private readonly TodoDbContext _context;

        private Repository<TodoActivity> _todoRepo;

        public UnitOfWork()
        {
            _context = new TodoDbContext();
        }

        public Repository<TodoActivity> TodoRepo
        {
            get
            {
                if (_todoRepo == null)
                    _todoRepo = new Repository<TodoActivity>(_context);
                return _todoRepo;
            }
        }
        public void Save()
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
        public void Dispose()
        {
            _todoRepo?.Dispose();
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
