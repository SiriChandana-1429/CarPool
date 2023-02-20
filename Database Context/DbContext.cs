using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace DatabaseContext;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
    : base(options) { }
    public MyDbContext() { }
    


    public DbSet<Credentials> Credentials => Set<Credentials>();
    public DbSet<OfferedRide> OfferedRides=>Set<OfferedRide>();
    public DbSet<BookedRide> BookedRides => Set<BookedRide>();

}