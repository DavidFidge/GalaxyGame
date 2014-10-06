using System;
using System.Linq;
using GalaxyGame.DataLayer;
using GalaxyGame.DataLayer.Components;
using GalaxyGame.DataLayer.EntityFramework;
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

                Console.WriteLine("Database created, reading galaxy");

                galaxies.ForEach(g => Console.WriteLine(g.Name));

                Console.ReadKey();
            }
        }
    }
}