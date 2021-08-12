using Core.Entities.Concrete;
using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.MSSQL
{
    public class SqlContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//"Server = (localdb)\mssqllocaldb; Database = Deneme; Trusted_Connection = true"
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = Banka; Trusted_Connection = true");
        }
       

        //Data Source=(localdb)\ProjectsV13;Initial Catalog=Deneme;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        public DbSet<Product> Products { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        
      
        public DbSet<Customer> Customers { get; set; }
     
        public DbSet<PrivateCustomer> PrivateCustomers { get; set; }
        public DbSet<CommercialCustomer> CommercialCustomers { get; set; }






    }
}