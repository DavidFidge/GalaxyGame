using System;
using System.Data.Entity;
using GalaxyGame.Model.Space;
using GalaxyGame.Model.Unity;

namespace GalaxyGame.DataLayer.EntityFramework
{
    public class BaseContext : DbContext
    {
        public BaseContext(string databaseName)
            : base(databaseName)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Vector2>();
            modelBuilder.ComplexType<Vector3>();
            modelBuilder.ComplexType<Color>();

            modelBuilder.Entity<Exploration>();
            modelBuilder.Entity<Galaxy>();
            modelBuilder.Entity<GalaxySector>();
            modelBuilder.Entity<GalaxySectorLink>()
                .HasRequired(gsl => gsl.SectorFrom)
                .WithMany(gs => gs.SectorLinks)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Moon>();
            modelBuilder.Entity<Planet>();
            modelBuilder.Entity<Player>();
            modelBuilder.Entity<SolarSystem>();
            modelBuilder.Entity<SpaceObject>();
            modelBuilder.Entity<Star>();
            modelBuilder.Entity<SubSystem>();
            modelBuilder.Entity<SystemPosition>();
            modelBuilder.Entity<SystemSector>();
            modelBuilder.Entity<User>();

            modelBuilder.Entity<SystemSetting>();

            modelBuilder.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));

            base.OnModelCreating(modelBuilder);
        }
    }
}