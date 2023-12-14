using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("client");

            builder.HasIndex(e => e.IdUser, "idUser").IsUnique();

            builder.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("firstName");
            builder.Property(e => e.IdUser)
                .HasColumnType("int(11)")
                .HasColumnName("idUser");

            
            builder.Property(e => e.SecondName)
                .HasMaxLength(50)
                .HasColumnName("secondName");
            builder.Property(e => e.SecondSurname)
                .HasMaxLength(50)
                .HasColumnName("secondSurname");
            builder.Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.Users).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_ibfk_1");
    }
}
