var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Serve default files (e.g., index.html) and static files from wwwroot
app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
