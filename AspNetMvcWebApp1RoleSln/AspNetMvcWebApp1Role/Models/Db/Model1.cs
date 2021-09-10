using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AspNetMvcWebApp1Role.Models.Db
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<TblCustomer> TblCustomers { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<TblUserRole> TblUserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCustomer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<TblUser>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<TblUser>()
                .Property(e => e.UserPass)
                .IsUnicode(false);

            modelBuilder.Entity<TblUser>()
                .Property(e => e.UserType)
                .IsUnicode(false);

            modelBuilder.Entity<TblUserRole>()
                .Property(e => e.PageName)
                .IsUnicode(false);
        }
    }
}
