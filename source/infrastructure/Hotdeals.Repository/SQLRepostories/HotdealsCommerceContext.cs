using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Hotdeals.Domain.ECommerceDomain.Entities;

#nullable disable

namespace Hotdeals.Repository.SQLRepostories
{
    public partial class HotdealsCommerceContext : DbContext
    {
        public HotdealsCommerceContext()
        {
        }

        public HotdealsCommerceContext(DbContextOptions<HotdealsCommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-HPPFIAI6\\SQLEXPRESS; Initial Catalog=HotdealsCommerce; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("Deliveries", "Shipping");

                entity.Property(e => e.ActualDeliveryDatde).HasColumnType("date");

                entity.Property(e => e.DeliveryCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DeliveryStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TargetDeliveryDate).HasColumnType("date");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryOrderId_Orders_Id");

                entity.HasOne(d => d.OrderItem)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.OrderItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryItemId_OrderItems_Id");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders", "Sales");

                entity.Property(e => e.BilledTo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDiscount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShippedTo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItems", "Sales");

                entity.Property(e => e.OrderItemDeliveryCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderItemDeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.OrderItemDeliveryStatus)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.OrderItemGrossAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderItemNetAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderItemPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderItemQuantity).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.OrderItemNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItemId_ProductsId");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products", "Catalogue");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
