using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GalaxyGame.Core.Interfaces;
using GalaxyGame.Core.Service;
using GalaxyGame.DataLayer.Components;

namespace GalaxyGame.DataLayer.Installers
{
    public class DataLayerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUnitOfWork>()
                    .ImplementedBy<UnitOfWork>()
                    .LifeStyle.Transient,

                Component.For<IUnitOfWorkFactory>()
                    .ImplementedBy<UnitOfWorkFactory>()
                    .LifeStyle.BoundTo<BaseService>(),

                Component.For<IUnitOfWorkInnerFactory>()
                    .AsFactory()
                );
        }
    }
}