using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcProje.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("UygulamaDbContextConnection") ?? throw new InvalidOperationException("Connection string 'UygulamaDbContextConnection' not found.");

builder.Services.AddDbContext<UygulamaDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Kullanici>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UygulamaDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    // GEREKLÝ HÝZMETLERÝN ENJEKSÝYONU/GETÝRÝLMESÝ
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Kullanici>>();

    // admin rolü yoksa oluþturur
    await roleManager.CreateAsync(new IdentityRole("admin"));

    var adminUser = new Kullanici()
    {
        UserName = "admin@admin.com",
        Email = "admin@admin.com",
        EmailConfirmed = true
    };

    // kullanýcý yoksa belirtilen parola ile oluþturur
    await userManager.CreateAsync(adminUser, "Ankara1.");

    // belirtilen kullanýcýya "admin" rolünü ata
    await userManager.AddToRoleAsync(adminUser, "admin");
}

app.Run();
