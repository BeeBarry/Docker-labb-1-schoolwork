using Microsoft.EntityFrameworkCore;
using BackendApi.Data;
using BackendApi.Models;

namespace BackendApi.Services;

public class TodoTaskService
{
    
        private readonly TodoDbContext _context;

        public TodoTaskService(TodoDbContext context)
        {
            _context = context;
        }


        // GET
        public async Task<List<TodoTask>> GetAllTodoTasksAsync()
        {
            return await _context.TodoTasks.ToListAsync();
        }


        // GET BY ID
        public async Task<TodoTask?> GetTodoTaskByIdAsync(int id)
        {
            return await _context.TodoTasks.FirstOrDefaultAsync(x => x.Id == id);
        }


        // POST
        public async Task<TodoTask> AddTodoTaskAsync(TodoTask todoTask)
        {
            _context.TodoTasks.Add(todoTask);
            await _context.SaveChangesAsync();
            return todoTask;
        }


        // DELETE
        public async Task<bool> DeleteTodoTaskAsync(int id)
        {
            var todo = await _context.TodoTasks.FindAsync(id);
            if (todo is null)
            {
                return false;
            }
            _context.TodoTasks.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }


        // PATCH
        public async Task<TodoTask?> UpdateIsDoneAsync(int id, bool isDone)
        {
            var todo = await _context.TodoTasks.FindAsync(id);
            if (todo is null)
            {
                return null;
            }

            todo.IsDone = isDone;
            await _context.SaveChangesAsync();
            return todo;
        }
}