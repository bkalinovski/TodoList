using System.Linq;
using System.Threading.Tasks;
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
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var todoList = await _todoService.GetListAsync();
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
        public async Task<IActionResult> Index(TodoViewModel model)
        {
            if (model == null)
            {
                ModelState.AddModelError("model", "Model is empty");
                return RedirectToAction("Index");
            }
            
            await _todoService.AddAsync(new TodoItem()
            {
                Id = model.TodoItem.Id,
                Description = model.TodoItem.Name
            });

            return RedirectToAction("Index");
        }
        
        [HttpDelete]
        public async Task Index(int id)
        {
            await _todoService.RemoveAsync(id);
        }
    }
}