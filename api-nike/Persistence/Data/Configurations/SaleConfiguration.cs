using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("sale");

            builder.HasIndex(e => e.IdBill, "idBill");

            builder.HasIndex(e => e.IdProduct, "idProduct");

            builder.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            builder.Property(e => e.IdBill)
                .HasColumnType("int(11)")
                .HasColumnName("idBill");
            builder.Property(e => e.IdProduct)
                .HasColumnType("int(11)")
                .HasColumnName("idProduct");
            builder.Property(e => e.Quantity)
                .HasColumnType("int(11)")
                .HasColumnName("quantity");

            builder.HasOne(d => d.Bills).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdBill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sale_ibfk_1");

            builder.HasOne(d => d.Products).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sale_ibfk_2");
    }
}
