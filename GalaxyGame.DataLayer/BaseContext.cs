using System;
using System.Data.Entity;
using System.Linq;
using GalaxyGame.Model;
using GalaxyGame.Model.Space;

namespace GalaxyGame.DataLayer
{
    public class BaseContext : DbContext
    {
        static BaseContext()
        {
        }

        public BaseContext()
            : base("name=GalaxyGame")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Galaxy>();
            modelBuilder.Entity<Moon>();
            modelBuilder.Entity<Planet>();
            modelBuilder.Entity<SpaceObject>();
            modelBuilder.Entity<Star>();
            modelBuilder.Entity<SubSystem>();
            modelBuilder.Entity<SolarSystem>();

            base.OnModelCreating(modelBuilder);
        }
    }
}