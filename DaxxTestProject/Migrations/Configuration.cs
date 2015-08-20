using DaxxTestProject.Models;
using System.Data.Entity.Migrations;

namespace DaxxTestProject.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DAL.RegistrationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.RegistrationContext context)
        {
            context.Countries.AddOrUpdate(country => country.Id,
                new Country {Id = 1, Name = "Country 1"},
                new Country {Id = 2, Name = "Country 2"},
                new Country {Id = 3, Name = "Country 3"}
                );

            context.SaveChanges();

            context.States.AddOrUpdate(state => state.Id,
                new State {Id = 1, Name = "State 1.1", CountryId = 1},
                new State {Id = 2, Name = "State 1.2", CountryId = 1},
                new State {Id = 3, Name = "State 1.3", CountryId = 1},
                new State {Id = 4, Name = "State 1.4", CountryId = 1},
                new State {Id = 5, Name = "State 1.5", CountryId = 1},
                new State {Id = 6, Name = "State 2.1", CountryId = 2},
                new State {Id = 7, Name = "State 2.2", CountryId = 2},
                new State {Id = 8, Name = "State 3.1", CountryId = 3},
                new State {Id = 9, Name = "State 3.2", CountryId = 3},
                new State {Id = 10, Name = "State 3.3", CountryId = 3},
                new State {Id = 11, Name = "State 3.4", CountryId = 3}
                );

            context.SaveChanges();
        }
    }
}
