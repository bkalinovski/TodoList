using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Todo.Contract;
using Todo.Contract.Models;
using Todo.Host.Models;

namespace Todo.Host.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodo _todoService;

        public TodoController(ITodo todoService)
        {
            _todoService = todoService;
            
            //PopulateList();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var todoList = _todoService.GetList();
            var viewModel = new TodoViewModel()
            {
                List = todoList.Select(t => new TodoItemModel()
                {
                    Id = t.Id,
                    Name = t.Description
                }).ToList(),
                TodoItem = new TodoItemModel()
            };
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(TodoViewModel model)
        {
            if (model == null)
            {
                ModelState.AddModelError("model", "Model is empty");
                return RedirectToAction("Index");
            }
            
            _todoService.Add(new TodoItem()
            {
                Id = model.TodoItem.Id,
                Description = model.TodoItem.Name
            });

            return RedirectToAction("Index");
        }
        
        [HttpDelete]
        public void Index(int id)
        {
            _todoService.Remove(id);
        }

        private void PopulateList()
        {
            if (_todoService.GetList().Count > 0)
            {
                return;
            }
            
            _todoService.Add(new TodoItem(1, "Item 1"));
            
            _todoService.Add(new TodoItem(2, "Item 2"));
            
            _todoService.Add(new TodoItem(3, "Item 3"));
            
            _todoService.Add(new TodoItem(4, "Item 4"));
        }
    }
}