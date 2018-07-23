using ASPWebIntroduce.Managers;
using ASPWebIntroduce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPWebIntroduce.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        public ActionResult Index()
        {
            var model = TodoManager.Instance.Todos;

            return View("TodoListView", model);
        }

        // GET: Todo/Details/5
        public ActionResult Details(int id)
        {
            var model = TodoManager.Instance.Get(id);

            return View("TodoItemView", model);
        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            return View("CreateTodoItem");
        }

        // POST: Todo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var model = new TodoItem();

                UpdateModel<TodoItem>(model, collection);

                TodoManager.Instance.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateTodoItem");
            }
        }

        // GET: Todo/Edit/5
        public ActionResult Edit(int id)
        {
            var model = TodoManager.Instance.Get(id);

            return View("EditTodoItemView", model);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var model = new TodoItem();

                UpdateModel<TodoItem>(model, collection);

                model.Id = id;

                TodoManager.Instance.Edit(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditTodoItemView");
            }
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(int id)
        {
            var model = TodoManager.Instance.Get(id);

            return View("RemoveView", model);
        }

        // POST: Todo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                TodoManager.Instance.Remove(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("RemoveView");
            }
        }
    }
}
