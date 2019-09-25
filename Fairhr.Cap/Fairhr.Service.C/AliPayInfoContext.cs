using Microsoft.EntityFrameworkCore;

namespace Fairhr.Service.C
{
    public class AliPayInfoContext : DbContext
    {
        public AliPayInfoContext(DbContextOptions<AliPayInfoContext> options) : base(options)
        {
        }

        public virtual DbSet<PayInfo> PayInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PayInfo>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).HasMaxLength(32);
                b.Property(e => e.OrderId).HasMaxLength(64);
                b.Property(e => e.Money).HasMaxLength(32);
                b.Property(e => e.stauts).HasColumnType("int(2)").HasDefaultValue(0);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}