using MeetUp.Models;
using Microsoft.EntityFrameworkCore;

public class MeetUpContext : DbContext
{
    public DbSet<Event> Events { get; set; }

    public MeetUpContext(DbContextOptions<MeetUpContext> options)
        : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("Host=localhost;Database=meetups");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .Property(b => b.Id)
            .ValueGeneratedOnAdd();
    }
}
