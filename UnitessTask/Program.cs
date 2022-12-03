using Microsoft.EntityFrameworkCore;
using UnitessLibrary.Abstracts;
using UnitessTask.Data;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddTransient<IEmployee, EmployeeRepository>();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseAuthorization();

    app.MapControllers();

    using var scope = app.Services.CreateScope();
    AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    DBObjects.Initial(context);

    app.Run();
}

