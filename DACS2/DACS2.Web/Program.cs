using AutoMapper;
using DACS2.Data;
using DACS2.Data.Reponsitory;
using DACS2.Share.Consts;
using DACS2.Web.WebConfig;
using DACS2.Web.WebConfig.Const;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DACS2DbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});
builder.Services.AddHttpContextAccessor();
// khai báo generic
builder.Services.AddScoped<BaseReponsitory>();
builder.Services.AddServiceRepositories();
//câu hình đăng nhập
builder.Services.AddAuthentication(AppConst.COOKIES_AUTH)
                .AddCookie(options =>
                {
                    options.LoginPath = AppConst.LOGIN_PATH;
                    options.ExpireTimeSpan = TimeSpan.FromHours(AppConst.LOGIN_TIMEOUT);
                    options.Cookie.HttpOnly = true;
                });
// cấu hình mapper
var mapperConfig = new MapperConfiguration(config =>
{
    config.AddProfile(new MapperConfig());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
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
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    app.UseEndpoints(endpoints =>
    {
        
        
        endpoints.MapControllerRoute(
                name: "Client",
                pattern: AppConst.LOGIN_PATH,
                defaults: new
                {
                    controller = "Auth",
                    action = "Login",
                    
                });
        endpoints.MapAreaControllerRoute(
            name: "Admin",
            areaName: "Admin",
            pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
        );
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );
    });
});

app.Run();
