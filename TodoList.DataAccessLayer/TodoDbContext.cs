using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.EntityLayer.Models;

namespace TodoList.DataAccessLayer
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoActivity> TodoActivities { get; set; }

        public TodoDbContext() : base("name=TodoConnString")
        {
            Database.SetInitializer(new MyInitializer());
        }
        public class MyInitializer : CreateDatabaseIfNotExists<TodoDbContext>
        {
            protected override void Seed(TodoDbContext context)
            {
                TodoActivity running = new TodoActivity { Id = 1, Name = "Running", Description = "Go to run at 21:10 pm" };
                context.TodoActivities.Add(running);
                base.Seed(context);
                context.SaveChanges();
            }
        }
    }
}
