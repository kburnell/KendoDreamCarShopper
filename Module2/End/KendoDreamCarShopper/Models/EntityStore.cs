using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace KendoDreamCarShopper.Models {

    public class EntityStore : DbContext {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; } 
        public DbSet<ModelImage> ModelImages { get; set; } 
        public DbSet<Order> Orders { get; set; }
    }
}