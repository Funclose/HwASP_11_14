
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting(); // активирует маршрутизаторы для обработки маршрутов
//app.UseDefaultFiles();
app.UseStaticFiles();

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    string path = request.Path.ToString().ToLower();
    if (path == "/")
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("Html/index.html");
    }
    else if (path == "/form" && request.Method == "POST")
    {
        string userName = request.Form["username"];
        string userPhone = request.Form["userPhone"];
        await response.WriteAsync($"userName - {userName}{Environment.NewLine}userPhone - {userPhone}");


    }
    else if (path == "/form")
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("Html/form.html");
    }


    
    else if (path == "/greeting" && request.Method == "POST")
    {
        string userName = request.Form["name"];
        await response.WriteAsync($"Hello: {userName}");

    }
    else if (path == "/greeting")
    {
        
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("api/greeting.html");
    }


});



app.Run();

public class NameRequest
{ 
    public string Name { get; set; }
}