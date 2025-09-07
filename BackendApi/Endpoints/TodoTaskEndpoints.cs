using Microsoft.EntityFrameworkCore;
using BackendApi.Models;
using BackendApi.Services;

namespace BackendApi.Endpoints;

public static class TodoTaskEndpoints
{
        public static WebApplication MapTodoEndpoints(this WebApplication app)
        {
            // GET All
            app.MapGet("/api/todos", async (TodoTaskService service) =>
            {
                var todos = await service.GetAllTodoTasksAsync();
                return Results.Ok(todos);
            });


            // POST
            app.MapPost("/api/todos", async (TodoTaskService service, TodoTask todo) =>
            {
                if (string.IsNullOrEmpty(todo.Title))
                {
                    return Results.BadRequest("Title is required.");
                }

                await service.AddTodoTaskAsync(todo);
                return Results.Created($"/api/todos/{todo.Id}", todo);
            });


            // DELETE
            app.MapDelete("/api/todos/{id}", async (TodoTaskService service, int id) =>
            {
                var todo = await service.GetTodoTaskByIdAsync(id);

                if (todo == null)
                {
                    return Results.NotFound();
                }

                await service.DeleteTodoTaskAsync(todo.Id);
                return Results.Ok(todo.Title + " deleted");
            });

            // PATCH: ändra om todo är klar eller inte
            app.MapPatch("/api/todos/{id:int}/done", async (TodoTaskService service, int id, bool isDone) =>
            {
                var updated = await service.UpdateIsDoneAsync(id, isDone);

                if (updated is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(updated);
            });

            return app;
        }  
}