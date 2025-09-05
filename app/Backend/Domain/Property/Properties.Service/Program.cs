using Microsoft.EntityFrameworkCore;
using Properties.Service.Application.Extensions;
using Properties.Service.Infrastructure.Extensions;
using Properties.Service.Infrastructure.Http.HttpExtensions;
using Properties.Service.Infrastructure.Persistence.Contexts;
using Properties.Service.Infrastructure.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction() || Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true")
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(80); // Solo HTTP
    });
}

string connectionString = builder.Configuration.GetConnectionString("PropertyConnectionString");

builder.Services.AddApplication();
builder.Services.AddInfrastructure(opt => opt.ConnectionString = connectionString);

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PropertiesContext>();
    db.Database.Migrate();  // aplica todas las migraciones pendientes
    // opcional: insertar datos de seed si necesitas
}
app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


//app.UseHttpsRedirection();

app.RegisterEndpoints();
//app.UseSeedData();
app.Run();
