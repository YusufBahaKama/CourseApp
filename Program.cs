using Microsoft.Extensions.FileProviders;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddRazorPages();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseRouting();

app.MapControllerRoute(
    "CourseByReleased",
    "courses/released/{year}/{month}",
    new {Controller="Course", Action="ByReleased"},
    new {year=@"\d{4}", month=@"\d{2}"}
    );

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=home}/{action=index}/{id?}" // "? = optional"
    );
    
    endpoints.MapRazorPages();
});

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions{

    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
    RequestPath = "/Modules",

    OnPrepareResponse = ctx => {
        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=600");
    }
});



app.Run();
