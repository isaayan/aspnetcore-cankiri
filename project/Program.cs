using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using project.Data.Abstract;
using project.Data.Concrete.EfCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlite("Data Source=App_Data/Database.sqlite"));


builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<INewsRepository, EfNewsRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<IHistoryRepository, EfHistoryRepository>();
builder.Services.AddScoped<IPopulationRepository, EfPopulationRepository>();
builder.Services.AddScoped<IDistrictRepository, EfDistrictRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.LoginPath = "/Users/Login";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});


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
app.UseAuthentication();
app.UseAuthorization();

SeedData.TestVerileriniDoldur(app);

app.MapControllerRoute(
    name: "news_details",
    pattern: "news/details/{id}",
    defaults: new { controller = "News", action = "Details" }
);

app.MapControllerRoute(
    name: "news_url",
    pattern: "news",
    defaults: new { controller = "News", action = "News" }
);

app.MapControllerRoute(
    name: "history_url",
    pattern: "history",
    defaults: new { controller = "History", action = "History" }
);

app.MapControllerRoute(
    name: "population_url",
    pattern: "population",
    defaults: new { controller = "Population", action = "Population" }
);

app.MapControllerRoute(
    name: "district_url",
    pattern: "district",
    defaults: new { controller = "District", action = "District" }
);

app.MapControllerRoute(
    name: "sliderimage_url",
    pattern: "sliderimage",
    defaults: new { controller = "SliderImage", action = "SliderImage" }
);

app.MapControllerRoute(
    name: "user_url",
    pattern: "user",
    defaults: new { controller = "Admin", action = "UserList" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
