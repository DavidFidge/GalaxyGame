using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GalaxyGame.Service.Interfaces;
using GalaxyGame.Service.Services;

namespace GalaxyGame.Service.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDictionaryDataService>()
                    .ImplementedBy<DictionaryDataService>()
                    .LifeStyle.Singleton,
                Component.For<IGalaxyDataService>()
                    .ImplementedBy<GalaxyDataService>()
                    .LifeStyle.Transient,
                Component.For<IPlayerMovementDataService>()
                    .ImplementedBy<PlayerMovementDataService>()
                    .LifeStyle.Transient,
                Component.For<ISystemDataService>()
                    .ImplementedBy<SystemDataService>()
                    .LifeStyle.Transient,
                Component.For<ISystemSettings>()
                    .ImplementedBy<SystemSettings>()
                    .LifeStyle.Singleton
                );
        }
    }
}