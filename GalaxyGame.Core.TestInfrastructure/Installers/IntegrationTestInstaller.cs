using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GalaxyGame.Core.TestInfrastructure.Components;
using GalaxyGame.DataLayer.Interfaces;

namespace GalaxyGame.Core.TestInfrastructure.Installers
{
    public class IntegrationTestInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                // Unlike the real configuration, this is a singleton since we need the same database name for the whole test
                Component.For<IDatabaseConfiguration>()
                    .ImplementedBy<TestDatabaseConfiguration>()
                    .Named("TestDatabaseConfiguration")
                    .IsDefault()
                    .LifeStyle.Singleton
                );
        }
    }
}