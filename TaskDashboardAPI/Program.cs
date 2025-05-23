using Microsoft.EntityFrameworkCore;
using TaskDashboardAPI.Models.Entities;
using UserManagementAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Configure Task Assignment DbContext
builder.Services.AddDbContext<TaskDashboardDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaskDashboardDB")));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/dashboard", async (TaskDashboardDbContext db) => await db.DashboardData.ToListAsync());
app.MapPost("/dashboard", async (DashboardData dashboardData, TaskDashboardDbContext db) =>
{
    db.DashboardData.Add(dashboardData);
    await db.SaveChangesAsync();
    return Results.Created($"/dashboard/{dashboardData.Id}", dashboardData);
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
