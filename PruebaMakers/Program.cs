using Application.Class;
using Application.Interfaces;
using Infraestructure;
using Microsoft.EntityFrameworkCore;
using Repository.Class;
using Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("PruebaMakers")));

builder.Services.AddScoped<IApplicationUser, ApplicationUser>();
builder.Services.AddScoped<ILoanApplication, LoanApplication>();
builder.Services.AddScoped<IUserRespository, UserRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
