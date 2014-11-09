using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.DataLayer.Components;
using GalaxyGame.DataLayer.EntityFramework;
using GalaxyGame.Model.Space;

namespace GalaxyGame.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var databaseConfiguration = new DatabaseConfiguration();

            var uow = new UnitOfWork(new EntityFrameworkContext(databaseConfiguration));

            var galaxies = uow.Context.DbSet<Galaxy>().ToList();

            Console.WriteLine("Database created, reading galaxy");

            galaxies.ForEach(g => Console.WriteLine(g.Name));

            Console.ReadKey();
        }
    }
}