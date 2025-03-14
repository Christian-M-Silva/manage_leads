﻿using Manage_lead.Data;
using Manage_lead.Data.Repositories;
using Manage_lead.Data.Seeds;
using Manage_lead.Interfaces.IRepositories;
using Manage_lead.Interfaces.IServices;
using Manage_lead.Services;
using Manage_lead.Services.SendGrid;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ILeadRepository, LeadRepository>();
builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddSingleton<SendGridService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();

    Console.WriteLine("🔄 Restore dependencies...");
    var process = System.Diagnostics.Process.Start("dotnet", "restore");
    process.WaitForExit();

    Console.WriteLine("📦 Apply migrations...");
    dbContext.Database.Migrate();

    Console.WriteLine("🚀 Start Application...");

    SeedLeads.Initialize(dbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
