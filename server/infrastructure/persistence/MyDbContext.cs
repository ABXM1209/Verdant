using System.Text.Json;
using domain.entities;
using infrastructure.utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.persistence;

public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
{
    public MyDbContext CreateDbContext(string[] args)
    {
        // For design-time (migrations), read connection string from environment variable
        // Falls back to localhost if not set
        var builder = new DbContextOptionsBuilder<MyDbContext>();
        builder.UseNpgsql(EnvHelper.LoadAndGetConnectionString(true));
        
        return new MyDbContext(builder.Options);
    }
}
public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    public DbSet<Player> Players => Set<Player>();
    public DbSet<Creature> Creatures => Set<Creature>();
    public DbSet<User> Users => Set<User>();
    public DbSet<ElementalAffinity> ElementalAffinities => Set<ElementalAffinity>();
    public DbSet<Technique> Techniques => Set<Technique>();
    public DbSet<CreatureTechnique> CreatureTechniques => Set<CreatureTechnique>();
    public DbSet<Proficiency> Proficiencies => Set<Proficiency>();
    public DbSet<CreatureProficiency> CreatureProficiencies => Set<CreatureProficiency>();
    public DbSet<Profession> Professions => Set<Profession>();
    public DbSet<Ancestry> Ancestries => Set<Ancestry>();
    public DbSet<Item> Items => Set<Item>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Creature>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.CreatureId).IsUnique();
            entity.HasOne<Creature>().WithOne().HasForeignKey<Player>(e => e.CreatureId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne<Profession>().WithMany().HasForeignKey(e => e.ProfessionId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne<Ancestry>().WithMany().HasForeignKey(e => e.AncestryId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.PasswordHash).IsRequired();
        });

        modelBuilder.Entity<Profession>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });

        var ancestryElementsConverter = new ValueConverter<ICollection<string>, string>(
            value => JsonSerializer.Serialize(value, (JsonSerializerOptions?)null) ?? "[]",
            value => JsonSerializer.Deserialize<List<string>>(value, (JsonSerializerOptions?)null) ?? new List<string>());

        modelBuilder.Entity<Ancestry>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Size).IsRequired();
            entity.Property(e => e.Elements)
                .HasConversion(ancestryElementsConverter)
                .HasColumnType("jsonb")
                .HasDefaultValueSql("'[]'::jsonb");
        });

        modelBuilder.Entity<ElementalAffinity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Element).IsRequired();
            entity.HasOne<Creature>().WithMany().HasForeignKey(e => e.creatureId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Technique>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<CreatureTechnique>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne<Creature>().WithMany().HasForeignKey(e => e.CreatureId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne<Technique>().WithMany().HasForeignKey(e => e.TechniqueId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Proficiency>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<CreatureProficiency>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne<Creature>().WithMany().HasForeignKey(e => e.CreatureId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne<Proficiency>().WithMany().HasForeignKey(e => e.ProficiencyId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}