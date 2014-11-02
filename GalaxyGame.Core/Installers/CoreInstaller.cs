using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GalaxyGame.Core.Components;
using GalaxyGame.Core.Interfaces;

namespace GalaxyGame.Core.Installers
{
    public class CoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDateTimeProvider>()
                    .ImplementedBy<DateTimeProvider>()
                    .LifeStyle.Transient,
                Component.For<IRandomNumberProvider>()
                    .ImplementedBy<RandomNumberProvider>()
                    .LifeStyle.Singleton,
                Component.For<IRandomization>()
                    .ImplementedBy<Randomization>()
                    .LifeStyle.Transient
                );
        }
    }
}