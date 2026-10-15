using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HabitsDev.Api.database;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) 
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Application);
    }
}
