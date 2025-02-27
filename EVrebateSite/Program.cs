using Microsoft.Extensions.FileProviders;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Calculate the absolute path to the Frontend folder, which is outside the project folder.
var parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
var staticFilesPath = Path.Combine(parentDirectory, "Frontend");

// Configure default files to use the Frontend folder
var defaultFilesOptions = new DefaultFilesOptions
{
    FileProvider = new PhysicalFileProvider(staticFilesPath),
    RequestPath = ""
};
defaultFilesOptions.DefaultFileNames.Clear();
defaultFilesOptions.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(defaultFilesOptions);

// Configure the static file middleware to serve files from the Frontend folder
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(staticFilesPath),
    RequestPath = ""
});

app.Run();
