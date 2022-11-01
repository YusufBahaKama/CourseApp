using Microsoft.Extensions.FileProviders;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddRazorPages();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseRouting();
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
