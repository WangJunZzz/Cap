using Microsoft.EntityFrameworkCore;

namespace Fairhr.Service.A
{
    public class OrderInfoContext:DbContext
    {
        public OrderInfoContext(DbContextOptions<OrderInfoContext> options)
            :base(options)
        {
            
        }
        public virtual DbSet<OrderInfo> OrderInfo { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderInfo>(e =>
            {
                e.HasKey(s => s.Id);
                e.Property(s => s.Id).HasMaxLength(32);
                e.Property(s => s.Name).HasMaxLength(64);
                e.Property(s => s.Money).HasMaxLength(32);
                e.Property(s => s.stauts).HasColumnType("int(2)").HasDefaultValue(0);
            });
            base.OnModelCreating(builder);
        }
    }
}