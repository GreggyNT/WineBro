using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api.Entities;

namespace api.Context;

public partial class AppbContext : DbContext
{
    public AppbContext()
    {
    }

    public AppbContext(DbContextOptions<AppbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bottle> Bottles { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }
    
    public virtual DbSet<Grapes> Grapes { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Spot> Spots { get; set; }

    public virtual DbSet<Wine> Wines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Database=WineBro;Port=5432;User Id =postgres;Password=postgres;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<Bottle>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("bottles", "wineBro");

            entity.Property(e => e.SupplyId).HasColumnName("supply_id");
            entity.Property(e => e.WineId).HasColumnName("wine_id");

            entity.HasOne(d => d.Supply).WithMany()
                .HasForeignKey(d => d.SupplyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("spot_FK");

            entity.HasOne(d => d.Wine).WithMany()
                .HasForeignKey(d => d.WineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wine_FK_1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_id_PK");

            entity.ToTable("category", "wineBro");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Sweetness).HasColumnName("sweetness");
            entity.Property(e => e.Color).HasColumnName("color");
        });

        modelBuilder.Entity<Grapes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("grapes_PK");
            
            entity.ToTable("grapes", "wineBro");
            
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Grape).HasColumnName("grapes");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("country_id_PK");

            entity.ToTable("country", "wineBro");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("prod_PK");

            entity.ToTable("producer", "wineBro");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("'-1'::integer")
                .HasColumnName("id");
            entity.Property(e => e.Details).HasColumnName("details");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.RegionId).HasColumnName("region_id");

            entity.HasOne(d => d.Region).WithMany(p => p.Producers)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("prod_reg_FK");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("region_id_PK");

            entity.ToTable("region", "wineBro");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.Country).WithMany(p => p.Regions)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("country_fk");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("score_PK");

            entity.ToTable("score", "wineBro");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Acidity).HasColumnName("acidity");
            entity.Property(e => e.Bitterness).HasColumnName("bitterness");
            entity.Property(e => e.Overall).HasColumnName("overall");
            entity.Property(e => e.Sweetness).HasColumnName("sweetness");
        });

        modelBuilder.Entity<Spot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("spot_PK");

            entity.ToTable("spot", "wineBro");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Coords).HasColumnName("coords");
        });

        modelBuilder.Entity<Wine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wine_id_PK");

            entity.ToTable("wine", "wineBro");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AlcoholPercentage).HasColumnName("alcohol_percentage");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Grapes).HasColumnName("grapes");
            entity.Property(e => e.Name).HasColumnName("name"); 
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProdId).HasColumnName("prod_id");
            entity.Property(e => e.Recs).HasColumnName("recs");
            entity.Property(e => e.ScoreId).HasColumnName("score_id");
            entity.Property(e => e.YearProduced).HasColumnName("year_produced");
            entity.Property(e => e.IsBestSeller).HasColumnName("is_best_seller");
            entity.Property(e => e.IsNewArr).HasColumnName("is_new_arr");
            entity.Property(e => e.IsSpecOffer).HasColumnName("is_spec_offer");

            entity.HasOne(d => d.Category).WithMany(p => p.Wines)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("wine_cat_FK");

            entity.HasOne(d => d.Prod).WithMany(p => p.Wines)
                .HasForeignKey(d => d.ProdId)
                .HasConstraintName("wine_prod_Fk");

            entity.HasOne(d => d.Score).WithMany(p => p.Wines)
                .HasForeignKey(d => d.ScoreId)
                .HasConstraintName("wine_score_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
