using System;
using System.Collections.Generic;
using ContactList.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactList.DAL.DBContext;

public partial class ContactsContext : DbContext
{
    public ContactsContext()
    {
    }

    public ContactsContext(DbContextOptions<ContactsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adresses).HasColumnType("char(250)");
            entity.Property(e => e.DateBirth).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasColumnType("char(50)");
            entity.Property(e => e.Image)
                .HasColumnType("char(250)")
                .HasColumnName("image");
            entity.Property(e => e.PhoneNumber).HasColumnType("char(50)");
            entity.Property(e => e.SecondName).HasColumnType("char(50)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
