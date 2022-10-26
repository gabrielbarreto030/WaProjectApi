using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Teste2022_1;
using TesteWaProject.Repository.Context;

namespace TesteWaProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
     
    
      private readonly ILogger<TodoController> _logger;
      private TodoContext db = new TodoContext();

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet("retornartodos")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Todo>> Get()
        {
            
            var todos = db.Todos.OrderBy(b => b.TodoId);

            return Ok(todos);
        } 
        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<Todo>  Post([FromBody]Todo todo)
        {
          
            var c= db.Add(todo);
            db.SaveChanges();
            

            return Ok();
        } 
        [HttpPut]
        [AllowAnonymous]
        public ActionResult<Todo>  Put([FromBody]Todo todo)
        {
          
       
            var todoMain = db.Todos.SingleOrDefault(b => b.TodoId==todo.TodoId);
            if (todoMain != null)
            {
                todoMain.Title = todo.Title;
                todoMain.isReady = todo.isReady;
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
         
           

           
        }
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public ActionResult<Todo>  Delete(int id)
        {
            var todoMain = db.Todos.SingleOrDefault(b => b.TodoId == id);
            if (todoMain != null)
            {
              
                db.Remove(todoMain);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
      




        }

    }
}