using CleanCodeExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExample.Infrastructure.Contexts
{
    public class AppliconDealContext : DbContext
    {
        public AppliconDealContext(DbContextOptions<AppliconDealContext> options)
           : base(options)
        {
        }

        public DbSet<Deal> Deals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Here we identify the Id property to be set to Identity
            // Also, we use change the PropertySaveBehavior on the same
            // property to ignore the values 

            modelBuilder.Entity<Deal>(b =>
            {
                b.ToTable("DealTb");
                b.HasKey(e => e.Name);
            }
           );
        }
    }

}
