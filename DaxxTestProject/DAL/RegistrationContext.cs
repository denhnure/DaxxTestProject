using System.Data.Entity;
using DaxxTestProject.Models;

namespace DaxxTestProject.DAL
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext()
            : base("RegistrationContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
    }
}