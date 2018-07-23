using ASPWebIntroduce.Managers;
using ASPWebIntroduce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ASPWebIntroduce.Controllers.Api
{
    public class TodoController : ApiController
    {
        // GET: api/TodoApi
        public IEnumerable<TodoItem> Get()
        {
            return TodoManager.Instance.Todos;
        }

        // GET: api/TodoApi/5
        public IHttpActionResult Get(int id)
        {
            var item = TodoManager.Instance.Get(id);

            if(item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST: api/TodoApi
        public IHttpActionResult Post([FromBody]TodoItem value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            TodoManager.Instance.Add(value);

            return Ok(value);
        }

        // PUT: api/TodoApi/5
        public IHttpActionResult Put(int id, [FromBody]TodoItem value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                TodoManager.Instance.Edit(value);
            }
            catch (InvalidOperationException e)
            {
                return NotFound();
            }

            return Ok(value);
        }

        // DELETE: api/TodoApi/5
        public IHttpActionResult Delete(int id)
        {
            var removeresult = TodoManager.Instance.Remove(id);

            if (!removeresult)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
