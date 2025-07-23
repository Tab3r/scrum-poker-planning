using System;
using Microsoft.EntityFrameworkCore;
using PokerPlanningBackend.Infrastructure.EntityFramework.Entities;

namespace PokerPlanningBackend.Infrastructure.EntityFramework;

public class PokerPlanningSQLiteContext : DbContext
{
    public DbSet<CardEntity> Cards { get; set; }

    public string DatabasePath { get; }

    public PokerPlanningSQLiteContext(DbContextOptions<PokerPlanningSQLiteContext> options)
        : base(options)
    {
        var localfolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var localFile = System.IO.Path.Combine(localfolder, "db", "pokerplanning.db");
        this.DatabasePath = localFile;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
        }
    }
}
