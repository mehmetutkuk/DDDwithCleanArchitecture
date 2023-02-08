using DDDOA.SolutionTemplate.API;
using DDDOA.SolutionTemplate.Application;
using DDDOA.SolutionTemplate.Insfrastructure;
using DDDOA.SolutionTemplate.Insfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddSwaggerGen();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    
    
    using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<CompanyWebcastDbContext>();

                // Here is the migration executed
                dbContext.Database.Migrate();
            }
    
    app.Run();
    
}