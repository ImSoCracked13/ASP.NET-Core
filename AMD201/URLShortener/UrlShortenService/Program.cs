using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using UserLinkService.Data;
using UserLinkService.Models;
using UserLinkService.Repositories;
using UserLinkService.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext to the container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));



// Add repository to the container
builder.Services.AddScoped<IUserLinkRepository, UserLinkRepository>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
context.Database.EnsureCreated();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowAll"); // Use the CORS policy
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// API to shorten the URL
app.MapPost("/api/userlinks/create", async (HttpContext context, ApplicationDbContext dbContext, IUserLinkRepository userLinkRepository) =>
{
    using var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();
    var userLink = JsonSerializer.Deserialize<UserLink>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

    if (userLink == null || string.IsNullOrEmpty(userLink.Link))
    {
        context.Response.StatusCode = 400; // Bad Request
        await context.Response.WriteAsync("Invalid link");
        return;
    }

    var baseUrl = $"{context.Request.Scheme}://{context.Request.Host}/api";
    userLinkRepository.GenerateNewLink(userLink, baseUrl);

    context.Response.ContentType = "application/json";
    await context.Response.WriteAsync(JsonSerializer.Serialize(userLink));
});

// API to redirect to the original URL using the shortened link
app.MapGet("/api/{newuserlink}", async (string newuserlink, ApplicationDbContext dbContext) =>
{
    var shortenUrl = await dbContext.UserLinks.FirstOrDefaultAsync(s => s.ShortenLink.EndsWith(newuserlink));

    if (shortenUrl is null)
    {
        return Results.NotFound();
    }

    return Results.Redirect(shortenUrl.Link);
});



app.Run();
