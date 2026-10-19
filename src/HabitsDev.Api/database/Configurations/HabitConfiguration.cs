using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabitsDev.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HabitsDev.Api.database.Configurations;

public class HabitConfiguration : IEntityTypeConfiguration<Habit>
{
    public void Configure(EntityTypeBuilder<Habit> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(h => h.Id).HasMaxLength(500);

        builder.Property(h => h.Name).HasMaxLength(100);
        builder.Property(h => h.Desciption).HasMaxLength(500);

        builder.OwnsOne(h => h.Frequency);
        builder.OwnsOne(h => h.Target , targetBulider =>
        {
            targetBulider.Property(t => t.Unit).HasMaxLength(100);
        });

        builder.OwnsOne(h => h.Milestone);
    }
}
