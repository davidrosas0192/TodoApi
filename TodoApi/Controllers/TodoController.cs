using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _todoContext;

        public TodoController(TodoContext todoContext)
        {
            _todoContext = todoContext;

            if(_todoContext.TodoItems.Count() == 0)
            {
                //create a new todoItem if collection is empty,
                //wich means you can't delete al todoItems
                _todoContext.TodoItems.Add(new TodoItem { Name = "item1" });
                _todoContext.SaveChanges();
            }
        }
    }
}
