using Model;
using System.Data.Entity;

namespace ORM
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<compte> compte { get; set; }
        public virtual DbSet<transac> transac { get; set; }
        public virtual DbSet<type> type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<client>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.compte)
                .WithMany(e => e.client)
                .Map(m => m.ToTable("client_compte"));

            modelBuilder.Entity<compte>()
                .Property(e => e.libelle)
                .IsUnicode(false);

            modelBuilder.Entity<compte>()
                .HasMany(e => e.transac)
                .WithRequired(e => e.compte)
                .HasForeignKey(e => e.compte_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<type>()
                .Property(e => e.type1)
                .IsUnicode(false);

            modelBuilder.Entity<type>()
                .HasMany(e => e.transac)
                .WithRequired(e => e.type)
                .HasForeignKey(e => e.type_id)
                .WillCascadeOnDelete(false);
        }
    }
}
