using lapshop.Areas.bl;
using lapshop.Helpers;
using lapshop.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using NuGet.Configuration;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LapShopContext>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(option => {
    option.Password.RequiredLength = 10;


}).AddEntityFrameworkStores<LapShopContext>();

builder.Services.ConfigureApplicationCookie(option => {

    option.AccessDeniedPath = "/admin/User/Register";
    option.Cookie.Name = "Cookie";
    option.Cookie.HttpOnly = true;
    option.ExpireTimeSpan = TimeSpan.FromMinutes(750);
    option.LoginPath = "/admin/User/Login";
    option.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    option.SlidingExpiration = true;

});


builder.Services.AddScoped<iCategory, ClsCategory>();
builder.Services.AddScoped<ITems, clsItems>();
builder.Services.AddScoped<ISalesInvoice, clsSalesInvoice>();
builder.Services.AddScoped<ISalesInvoiceItem, clsSalesInvoiceItem>();
builder.Services.AddScoped<Iitemtype, clsItemType>();
builder.Services.AddScoped<Ios, clsOs>();
builder.Services.AddScoped<ISetting, Clssetting>();

builder.Services.AddSession();

builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();

builder.Services.Configure<AdminSettings>(builder.Configuration.GetSection("AdminSettings"));





var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string adminEmail = "admin@gmail.com";
    string adminPassword = "Admin@12345"; // الباسورد لازم يكون قوي علشان Identity يقبله

    // 1. تأكد إن Role اسمه Admin موجود
    if (!await roleManager.RoleExistsAsync("AdMIN"))
    {
        await roleManager.CreateAsync(new IdentityRole("AdMIN"));
    }

    // 2. تأكد إن اليوزر مش موجود بالفعل
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        var user = new IdentityUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
        else
        {
            // لو فيه مشكلة في إنشاء المستخدم، اطبعها في الكونسول
            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.Description);
            }
        }
    }
}



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/home/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.UseEndpoints(endpoint => {


  
    endpoint.MapControllerRoute(name: "Default",
   pattern: "{area=admin}/{controller=Home}/{action=Main}/{id?}");

    endpoint.MapControllerRoute(name: "categoryRoute",
     pattern: "{area=admin}/{controller=Category}/{action=List}/{id?}");





});


app.Run();
