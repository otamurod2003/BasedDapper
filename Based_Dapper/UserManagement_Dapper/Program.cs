using UserManagement_Dapper.Models;

var builder = WebApplication.CreateBuilder(args);
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddTransient<IUserRepository, UserRepository>(provider=>new UserRepository(connectionString));
var app = builder.Build();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.Run();
