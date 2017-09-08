using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using MySql.Data.Entity;
using System.Configuration;

namespace Arkanis.Repositories.DataModel
{
    [DbConfigurationType(typeof(MultipleDbConfiguration))]
    public partial class ArkanisDBContext : DbContext
    {
        public static string ArkanisConnectionString { get { return ConfigurationManager.ConnectionStrings["Arkanis"].ConnectionString; } }

        public ArkanisDBContext() : base(MultipleDbConfiguration.GetMySqlConnection(ArkanisConnectionString), true)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Database.CommandTimeout = 60;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");

            modelBuilder.Entity<Product>().ToTable("Product")
                .HasMany(a => a.categories)
                .WithMany(b => b.products)
                .Map(m => m.MapLeftKey("categoryId")
                    .MapRightKey("productId")
                    .ToTable("ProductCategory"));
        }

		public DbSet<Product> Product { get; set; }
		public DbSet<Category> Category { get; set; }

        [System.Diagnostics.DebuggerHidden]
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var nex = ex.GetBaseException();
                if (nex != null)
                {
                    throw new ApplicationException(string.Format("Save Changes DBUpdate Exception : {0}", nex.Message));
                }
                else {
                    throw new ApplicationException(string.Format("Save Changes DBUpdate Exception : {0}", ex.Message));
                }                
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}
