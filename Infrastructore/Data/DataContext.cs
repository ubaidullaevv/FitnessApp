using System.Diagnostics;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Data;

public class DataContext(DbContextOptions<DataContext> options):DbContext(options)
{
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<WorkoutSession> WorkoutSessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Trainer>()
        .HasMany(t=>t.WorkoutSessions)
        .WithOne(w=>w.Trainer);

        modelBuilder.Entity<Workout>()
        .HasMany(w=>w.WorkoutSessions)
        .WithOne(v=>v.Workout);


        modelBuilder.Entity<Client>()
        .HasMany(c=>c.WorkoutSessions)
        .WithOne(w=>w.Client);
    }
}
