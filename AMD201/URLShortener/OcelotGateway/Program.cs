using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddJsonFile(
  "ocelot.json",
  optional: false,
  reloadOnChange: true
  );

builder.Services.AddOcelot(builder.Configuration).AddCacheManager(x =>
{
  x.WithDictionaryHandle();
});


// Add this in Program.cs
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAll");



//add them *
app.UseCors("AllowAll"); // Use the CORS policy


//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseOcelot().Wait();


app.Run();
