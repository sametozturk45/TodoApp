using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.DataAccessLayer;

namespace TodoList.Web.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        public ActionResult List()
        {
            using(UnitOfWork uow = new UnitOfWork())
                return View(uow.TodoRepo.GetAll());
        }
    }
}