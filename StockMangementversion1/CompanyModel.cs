namespace StockMangementversion1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CompanyModel : DbContext
    {
        public CompanyModel()
            : base("name=CompanyModel1")
        {
        }

        public virtual DbSet<Measure_Unit> Measure_Unit { get; set; }
        public virtual DbSet<Permission_Product> Permission_Product { get; set; }
        public virtual DbSet<PermissionModel> PermissionModels { get; set; }
        public virtual DbSet<PersonModel> PersonModels { get; set; }
        public virtual DbSet<ProductModel> ProductModels { get; set; }
        public virtual DbSet<ProdutsInStock> ProdutsInStocks { get; set; }
        public virtual DbSet<StockModel> StockModels { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Transfer_Product> Transfer_Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Measure_Unit>()
                .Property(e => e.Unit_Name)
                .IsUnicode(false);

            modelBuilder.Entity<PermissionModel>()
                .Property(e => e.Per_Type)
                .IsUnicode(false);

            modelBuilder.Entity<PermissionModel>()
                .HasMany(e => e.Permission_Product)
                .WithRequired(e => e.PermissionModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonModel>()
                .Property(e => e.P_Name)
                .IsUnicode(false);

            modelBuilder.Entity<PersonModel>()
                .Property(e => e.P_MobilePhone)
                .IsUnicode(false);

            modelBuilder.Entity<PersonModel>()
                .Property(e => e.P_fax)
                .IsUnicode(false);

            modelBuilder.Entity<PersonModel>()
                .Property(e => e.P_email)
                .IsUnicode(false);

            modelBuilder.Entity<PersonModel>()
                .Property(e => e.P_website)
                .IsUnicode(false);

            modelBuilder.Entity<PersonModel>()
                .Property(e => e.P_Type)
                .IsUnicode(false);

            modelBuilder.Entity<PersonModel>()
                .HasMany(e => e.PermissionModels)
                .WithOptional(e => e.PersonModel)
                .HasForeignKey(e => e.Person_Id);

            modelBuilder.Entity<ProductModel>()
                .Property(e => e.Product_Name)
                .IsUnicode(false);

            modelBuilder.Entity<ProductModel>()
                .HasMany(e => e.Permission_Product)
                .WithRequired(e => e.ProductModel)
                .HasForeignKey(e => e.product_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductModel>()
                .HasMany(e => e.ProdutsInStocks)
                .WithRequired(e => e.ProductModel)
                .HasForeignKey(e => e.product_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductModel>()
                .HasMany(e => e.Transfer_Product)
                .WithRequired(e => e.ProductModel)
                .HasForeignKey(e => e.product_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductModel>()
                .HasMany(e => e.Measure_Unit)
                .WithMany(e => e.ProductModels)
                .Map(m => m.ToTable("measure_ProductByUnit").MapLeftKey("Product_Code").MapRightKey("Unit_Id"));

            modelBuilder.Entity<StockModel>()
                .Property(e => e.Stock_Name)
                .IsUnicode(false);

            modelBuilder.Entity<StockModel>()
                .Property(e => e.Stock_address)
                .IsUnicode(false);

            modelBuilder.Entity<StockModel>()
                .Property(e => e.Stock_Admin)
                .IsUnicode(false);

            modelBuilder.Entity<StockModel>()
                .HasMany(e => e.ProdutsInStocks)
                .WithRequired(e => e.StockModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockModel>()
                .HasMany(e => e.Transfer_Product)
                .WithRequired(e => e.StockModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transfer_Product>()
                .Property(e => e.From_Stock)
                .IsUnicode(false);

            modelBuilder.Entity<Transfer_Product>()
                .Property(e => e.To_Stock)
                .IsUnicode(false);
        }
    }
}
