using DACS2.Data.Config;
using DACS2.Data.DataSender;
using DACS2.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DACS2.Data
{
    public class DACS2DbContext :DbContext
    {
        public DACS2DbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CategoryNews> categoryNews{ get; set; }
        public DbSet<CategoryProduct> categoryProducts { get; set; }
        public DbSet<Color>colors { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<MstPerMission> mstPerMissions { get; set; }
        public DbSet<News> news { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<RolePermission>rolePermissions  { get; set; }
        public DbSet<Size> sizes { get; set; }
        public DbSet<User>  users { get; set; }
        public DbSet<Voucher> vouchers { get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<Policy> policies { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<SysTempt> systems { get; set; }
        public DbSet<Supplier> supplierss { get; set; }
        public DbSet<Report> reports { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColorConfig());
            modelBuilder.ApplyConfiguration(new ImageConfig());
            modelBuilder.ApplyConfiguration(new InvoiceDetailsConfig());
            modelBuilder.ApplyConfiguration(new NewsConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new RolePermissionConfig());
            modelBuilder.ApplyConfiguration(new SizeConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new IvoiceConfig());

            // tạo dữ liệu
            modelBuilder.Entity<MstPerMission>().SeedData();
            modelBuilder.Entity<Status>().SeedData();
        }

    }
}
