using FluentValidation;
using Microsoft.AspNetCore.Identity;
using WebApp.Application.DSL.Commands.CreateDSL;
using WebApp.Application.Extensions;
using WebApp.Infrastructure.Extensions;
using WebApp.Infrastructure.Persistance;
using WebApp.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IValidator<CreateDSLCommand>, CreateDSLCommandValidator>();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<WebAppDbContext>();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Home/Index";         // dla niezalogowanych
    options.AccessDeniedPath = "/Home/Index";  // dla braku uprawnieñ
});
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<ModemSeeder>();
    var dslSeeder = scope.ServiceProvider.GetRequiredService<DSLSeeder>();

    await dslSeeder.SeedDSL();
    await seeder.SeedModem();
}

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
