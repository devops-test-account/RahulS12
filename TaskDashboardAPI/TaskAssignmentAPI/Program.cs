using Microsoft.EntityFrameworkCore;
using TaskAssignmentAPI.Models.Entities;
using UserManagementAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Configure User Management DbContext
builder.Services.AddDbContext<TaskAssignmentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaskAssignmentDB")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.MapPost("/assignments", async (TaskAssignment assignment, TaskAssignmentDbContext db, IHttpClientFactory httpClientFactory) =>
{
    // Check if the user exists in UserManagementAPI
    var client = httpClientFactory.CreateClient();
    var userResponse = await client.GetAsync($"http://localhost:5001/users/{assignment.UserId}"); // UserManagementAPI URL
    if (!userResponse.IsSuccessStatusCode)
    {
        return Results.BadRequest("Invalid User ID");
    }
    // Check if the task exists in TaskCreationAPI
    var taskResponse = await client.GetAsync($"http://localhost:5002/tasks/{assignment.TaskId}"); // TaskCreationAPI URL
    if (!taskResponse.IsSuccessStatusCode)
    {
        return Results.BadRequest("Invalid Task ID");
    }
    db.TaskAssignments.Add(assignment);
    await db.SaveChangesAsync();
    // Notify TaskDashboardAPI to update task count
    var dashboardData = new { UserId = assignment.UserId, TaskCount = 1 }; // Adjust based on your logic
    await client.PostAsJsonAsync("http://localhost:5004/dashboard", dashboardData);
    return Results.Created($"/assignments/{assignment.Id}", assignment);
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
