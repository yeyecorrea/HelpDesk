using System;
using AutoMapper;
using HelpDesk.Business.Interfaces;
using HelpDesk.Business.Mapping;
using HelpDesk.Business.Services;
using HelpDesk.Data.DataContext;
using HelpDesk.Data.Interfaces;
using HelpDesk.Data.Repositories;
using HelpDesk.Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Database Context
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();

// Add Automapper
builder.Services.AddAutoMapper(typeof(AdminProfile));

// Add Repositories
builder.Services.AddScoped<IAuthAdminRepository, AuthAdminRepository>();

// Add Services
builder.Services.AddScoped<IAuthAdminService, AuthAdminService>();

//Configuracion cookies
builder.Services.AddAuthentication()
    .AddCookie("UserScheme", options =>
    {
        options.LoginPath = "/user/login";
        options.AccessDeniedPath = "/user/denied";
    })
    .AddCookie("AdminScheme", options =>
    {
        options.LoginPath = "/admin/login";
        options.AccessDeniedPath = "/admin/denied";
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

app.UseEndpoints(endpoints =>
{

    // Ruta para áreas (DEBE ir primero)
    // Mapeo explícito para el área Admin
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller}/{action}/{id?}",
        defaults: new { controller = "Home", action = "Index" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
