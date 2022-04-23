using Microsoft.EntityFrameworkCore;
using JobSearchApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using JobSearchApp.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityContextConnection");;

builder.Services.AddDbContextFactory<IdentityContext>(opt =>
    opt.UseSqlite(connectionString));
builder.Services.AddDefaultIdentity<IdentityUser>(options => 
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false; 
})
    .AddEntityFrameworkStores<IdentityContext>();
//builder.Services.AddScoped<AuthenticationStateProvider>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpContextAccessor();


builder.Services.AddDbContextFactory<AppDbContext>(opt =>
    opt.UseSqlite($"Data Source={nameof(AppDbContext.AppDb)}.db"));

builder.Services.AddScoped<ApplicationService>();

//Add HttpClient
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
