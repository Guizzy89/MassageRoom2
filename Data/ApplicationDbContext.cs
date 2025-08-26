using Microsoft.EntityFrameworkCore;
using MassageRoom.Models;

namespace MassageRoom.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<MassageService> MassageServices { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Добавление начальных данных
        modelBuilder.Entity<MassageService>().HasData(new MassageService[]
        {
            new MassageService {Id = 1, Name="Классический массаж", Price=1500m, Description="Расслабляющий массаж всего тела"},
            new MassageService {Id = 2, Name="Антицеллюлитный массаж", Price=2000m, Description="Улучшение состояния кожи"}
        });

        modelBuilder.Entity<Booking>().HasData(new Booking[]
        {
            new Booking {Id = 1, SlotDate=new DateTime(2025,8,1,10,0,0), IsAvailable=true},
            new Booking {Id = 2, SlotDate=new DateTime(2025,8,1,12,0,0), IsAvailable=false, ClientName="Иван Иванов", PhoneNumber="+79001234567", Comment="Без комментариев"}
        });
    }
}