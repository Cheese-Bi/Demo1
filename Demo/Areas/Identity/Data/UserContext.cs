using Demo.Areas.Identity.Data;
using Demo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data;

public class UserContext : IdentityDbContext<AppUser>
{
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }
    public DbSet<Store> Store { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderDetail> OrderDetail { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<AppUser>()/*.ToTable("Store")*/
            .HasOne<Store>(au => au.Store)
            .WithOne(st => st.User)
            .HasForeignKey<Store>(st => st.UId);
        /*builder.Entity<Store>()
            .HasOne<AppUser>(st => st.User)
            .WithOne(st => st.Store)
            .HasForeignKey<AppUser>(st => st.Store);*/



        builder.Entity<Book>()
            .HasOne<Store>(b => b.Store)
            .WithMany(st => st.Books)
            .HasForeignKey(b => b.StoreId);
        builder.Entity<Order>()
            .HasOne<AppUser>(o => o.User)
            .WithMany(ap => ap.Orders)
            .HasForeignKey(o => o.UId);
        builder.Entity<OrderDetail>()
            .HasKey(od => new { od.OrderId, od.BookIsbn });
        builder.Entity<OrderDetail>()
            .HasOne<Order>(od => od.Order)
            .WithMany(or => or.OrderDetails)
            .HasForeignKey(od => od.OrderId);
        builder.Entity<OrderDetail>()
            .HasOne<Book>(od => od.Book)
            .WithMany(b => b.OrderDetails)
            .HasForeignKey(od => od.BookIsbn);
    }
}
