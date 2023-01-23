using Euronext.CompanyWebcast.API;
using Euronext.CompanyWebcast.Application;
using Euronext.CompanyWebcast.Insfrastructure;


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
    app.Run();
}