using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HabitsDev.Api.database;
using Microsoft.EntityFrameworkCore;

namespace HabitsDev.Api.Extensions;

public static class DatabaseExtensions
{
    public static async Task ApplyMigrationsAsync(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        await using AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        try
        {
            await context.Database.MigrateAsync();

            app.Logger.LogInformation("Database Migrations Applied Successfully");
        }
        catch(Exception ex)
        {
            app.Logger.LogError(ex,"An error Occurred While Appling Database Migrations.");
            throw;
        }
    }
}
