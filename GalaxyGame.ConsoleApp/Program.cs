using System;
using System.Linq;
using GalaxyGame.DataLayer;
using GalaxyGame.Model.Space;

namespace GalaxyGame.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var uow = new UnitOfWork(new EntityFrameworkContext()))
            {
                var galaxies = uow.Context.DbSet<Galaxy>().ToList();

                galaxies.ForEach(g => Console.WriteLine(g.Name));

                Console.ReadKey();

                galaxies.ForEach(g => g.Name = "changed");

                uow.Save();
            }

            using (var uow = new UnitOfWork(new EntityFrameworkContext()))
            {
                var galaxies = uow.Context.DbSet<Galaxy>().ToList();

                galaxies.ForEach(g => Console.WriteLine(g.Name));

                Console.ReadKey();
            }
        }
    }
}