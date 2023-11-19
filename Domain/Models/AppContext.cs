using System.Data.Entity;

namespace Domain.Models
{
    public partial class AppContext : DbContext
    {    
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Fotocenter> Fotocenters { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<ProvisionOfServices> ProvisionOfServices { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
