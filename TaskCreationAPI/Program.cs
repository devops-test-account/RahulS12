using Microsoft.EntityFrameworkCore;
using TaskCreationAPI.Models;
using TaskCreationAPI.Models.Entities;
using UserManagementAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Configure Task Creation DbContext
builder.Services.AddDbContext<TaskCreationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaskCreationDB")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/tasks", async (TaskCreationDbContext db) => await db.Tasks.ToListAsync());
app.MapGet("/tasks/{id}", async (int id, TaskCreationDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);
    return task is not null ? Results.Ok(task) : Results.NotFound();
});
app.MapPost("/tasks", async (TaskManager task, TaskCreationDbContext db) =>
{
    db.Tasks.Add(task);
    await db.SaveChangesAsync();
    // Notify TaskDashboardAPI about new task creation (if needed)
    using var client = new HttpClient();
    var dashboardUpdate = new DashboardUpdateDto { UserId = null, TaskCount = 0 }; // Use the named class
    await client.PostAsJsonAsync("http://localhost:5004/dashboard", dashboardUpdate);
    return Results.Created($"/tasks/{task.Id}", task);
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
