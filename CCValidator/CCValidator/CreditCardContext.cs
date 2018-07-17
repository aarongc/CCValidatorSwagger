using CCValidator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CCValidator
{
    public class CreditCardContext : DbContext
    {
        public CreditCardContext(): base("name=CCDataConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CreditCardContext>());
        }
        public DbSet<CreditCard> CreditCards { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCard>().Property(p => p.CardNumber).HasPrecision(16, 0);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}