using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using web_app_asp_net_mvc_code_first.Models.Entities;

namespace web_app_asp_net_mvc_code_first.Models
{
    public class ErrorLogContext : DbContext
    {
        public DbSet<Error> Errors { get; set; }
        public DbSet<ErrorType> ErrorTypes { get; set; }
        public DbSet<ErrorImage> ErrorImage { get; set; }
        public DbSet<User> Users { get; set; }

        public ErrorLogContext() : base("ErrorLogEntity") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Error>().HasOptional(x => x.ErrorImage).WithRequired().WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }

    }
}