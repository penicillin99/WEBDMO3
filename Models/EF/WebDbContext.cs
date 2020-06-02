namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebDbContext : DbContext
    {
        public WebDbContext()
            : base("name=WebDbContext")
        {
        }

        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<EMPLOYER> EMPLOYERs { get; set; }
        public virtual DbSet<MANAGER> MANAGERs { get; set; }
        public virtual DbSet<ROOM> ROOMs { get; set; }
        public virtual DbSet<TYPEROOM> TYPEROOMs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYER>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYER>()
                .HasMany(e => e.ROOMs)
                .WithRequired(e => e.EMPLOYER)
                .HasForeignKey(e => e.idEmployer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MANAGER>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<MANAGER>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<ROOM>()
                .Property(e => e.address)
                .IsUnicode(true);

            modelBuilder.Entity<ROOM>()
                .Property(e => e.acreage)
                .IsUnicode(false);

            modelBuilder.Entity<TYPEROOM>()
                .HasMany(e => e.ROOMs)
                .WithRequired(e => e.TYPEROOM)
                .HasForeignKey(e => e.idRoom)
                .WillCascadeOnDelete(false);
        }
    }
}
