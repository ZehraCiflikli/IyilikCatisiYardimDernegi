using Infrastructure.Interceptors;
using IyilikCatisi.Business;
using IyilikCatisi.Business.Abstract;
using IyilikCatisi.Business.Concrete.BaseConcrete.EntityFramework;
using IyilikCatisi.Data.Abstract;
using IyilikCatisi.Data.Concrete.EntityFramework.repository;
using IyilikCatisi.Business.MappingRules;
using FluentValidation.AspNetCore;
using IyilikCatisi.WebCoreUI.Filters;
using FluentValidation;
using IyilikCatisi.Business.ValidationRules.Areas.AdminPanel;
using IyilikCatisi.Model.ViewModel.Areas.AdminPanel;
using IyilikCatisi.WebCoreUI.Middlewares;
using System.Text.Json.Serialization;
using System.Configuration;
using IyilikCatisi.Business.ValidationRules.Front;
using IyilikCatisi.Model.ViewModel.Front;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.MaxDepth = 64;  //Ba��� da hata veriyor du ba��� sayfas� i�in eklendi
});

builder.Services.AddBusinessService();
builder.Services.AddSession();

builder.Services.AddScoped<AuditInterceptor>();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddMemoryCache();


//validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddTransient<IValidator<LoginVm>, LoginVmValidator>();
builder.Services.AddTransient<IValidator<KullaniciSignupVm>, KullaniciSignupValidator>();
builder.Services.AddTransient<IValidator<KullaniciSignInVm>, KullaniciSignInValidator>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ISessionManager,SessionManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();


string logfile = Path.Combine(Directory.GetCurrentDirectory(), "loglar.txt");

app.UseMiddleware<GlobalExceptionHandler>(logfile);
//   app.UseMiddleware<RequestResponseLogHandler>();

app.UseRouting();

app.UseAuthorization();

// AREA  
app.MapControllerRoute(
 name: "area",
 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

// MAIN SITE
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
