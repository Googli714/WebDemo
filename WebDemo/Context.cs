namespace WebDemo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Person_Table> Person_Table { get; set; }
        public virtual DbSet<Users_Table> Users_Table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person_Table>()
                .HasMany(e => e.Users_Table)
                .WithRequired(e => e.Person_Table)
                .HasForeignKey(e => e.PersonId)
                .WillCascadeOnDelete(false);
        }
    }
}
