using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UserInformation.Domain.Context;
using UserInformation.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"), options =>
    options.MigrationsAssembly("UserInformation.Infrastructure"));
});


// Add services to the container.
builder.Services.AddServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.UseMiddleware<ExceptionHandlingMiddleware>(); // we can use Custome Exception Middleware

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error"); // Redirect to error-handling endpoint
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
