using ASPWebIntroduce.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ASPWebIntroduce.Managers
{
    public class TodoManager
    {
        private List<TodoItem> _todos;

        public IEnumerable<TodoItem> Todos { get { return _todos; } }

        public static TodoManager Instance { get; private set; } = new TodoManager();

        protected TodoManager()
        {
            _todos = new List<TodoItem>();
        }

        public void Add(TodoItem item)
        {
            if (_todos.Count != 0)
            {
                item.Id = this._todos.Max(i => i.Id) + 1;
            }
            else
            {
                item.Id = 0;
            }


            _todos.Add(item);
        }

        public bool Remove(int id)
        {
            var item = Get(id);

            if (item == null)
            {
                return false;
            }

            return _todos.Remove(item);
        }

        public TodoItem Get(int id)
        {
            return _todos.SingleOrDefault(i => i.Id == id);
        }

        public void Edit(TodoItem item)
        {
            var removeResult = Remove(item.Id);

            if (removeResult)
            {
                Add(item);
            }
            else
            {
                throw new InvalidOperationException($"Not found todo item with {item.Id} id");
            }

        }
    }
}