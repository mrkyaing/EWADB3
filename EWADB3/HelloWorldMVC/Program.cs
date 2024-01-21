var builder = WebApplication.CreateBuilder(args);
//register the all the controllers & views to know the middleware
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");//url routings
app.MapGet("/home", () => "welcome to to my home");// register the url route
app.MapGet("/home/profile", () => "Hello,I am Mr Kyaing"); //route
//mapping the controller to each actions
app.MapDefaultControllerRoute();
app.Run();

