using System;
using System.Collections.Generic;
using Data;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Data.EFcontexts;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Policy> Policies { get; set; }

    public virtual DbSet<PolicyType> PolicyTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VwPolicyDetail> VwPolicyDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clients__3213E83FDE76262C");

            entity.ToTable("clients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Curp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("curp");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(255)
                .HasColumnName("gender");
            entity.Property(e => e.LastNameMaternal)
                .HasMaxLength(255)
                .HasColumnName("last_name_maternal");
            entity.Property(e => e.LastNamePaternal)
                .HasMaxLength(255)
                .HasColumnName("last_name_paternal");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.UsersId).HasColumnName("users_id");

            entity.HasOne(d => d.Country).WithMany(p => p.Clients)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__clients__country__403A8C7D");

            entity.HasOne(d => d.Users).WithMany(p => p.Clients)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK__clients__users_i__3F466844");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__country__7E8CD05501B2FFF2");

            entity.ToTable("country");

            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CountryName)
                .HasMaxLength(255)
                .HasColumnName("country_name");
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__policies__3213E83FEC2F784F");

            entity.ToTable("policies");

            entity.HasIndex(e => e.PolicyNumber, "UQ__policies__96916872380B9362").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(255)
                .HasColumnName("policy_number");
            entity.Property(e => e.PolicyTypeId).HasColumnName("policy_type_id");
            entity.Property(e => e.PremiumAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("premium_amount");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");

            entity.HasOne(d => d.Client).WithMany(p => p.Policies)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__policies__client__47DBAE45");

            entity.HasOne(d => d.PolicyType).WithMany(p => p.Policies)
                .HasForeignKey(d => d.PolicyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__policies__policy__46E78A0C");
        });

        modelBuilder.Entity<PolicyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__policy_t__3213E83FAB82E33C");

            entity.ToTable("policy_types");

            entity.HasIndex(e => e.Name, "UQ__policy_t__72E12F1B5A54ADD8").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F81ACAAD3");

            entity.ToTable("roles");

            entity.HasIndex(e => e.NameRol, "UQ__roles__0DC6757A937D429E").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameRol)
                .HasMaxLength(255)
                .HasColumnName("name_rol");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F9F284650");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .HasColumnName("password");
            entity.Property(e => e.RolId).HasColumnName("rol_id");

            entity.HasOne(d => d.Rol).WithMany(p => p.Users)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__users__rol_id__3A81B327");
        });

        modelBuilder.Entity<VwPolicyDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_policy_details");

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CountryName)
                .HasMaxLength(255)
                .HasColumnName("country_name");
            entity.Property(e => e.curp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("curp");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(255)
                .HasColumnName("gender");
            entity.Property(e => e.LastNameMaternal)
                .HasMaxLength(255)
                .HasColumnName("last_name_maternal");
            entity.Property(e => e.LastNamePaternal)
                .HasMaxLength(255)
                .HasColumnName("last_name_paternal");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.PolicyId).HasColumnName("policy_id");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(255)
                .HasColumnName("policy_number");
            entity.Property(e => e.PolicyTypeId).HasColumnName("policy_type_id");
            entity.Property(e => e.PolicyTypeName)
                .HasMaxLength(255)
                .HasColumnName("policy_type_name");
            entity.Property(e => e.PremiumAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("premium_amount");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
