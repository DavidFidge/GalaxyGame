using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using GalaxyGame.Service.Interfaces;
using GalaxyGame.Service.Services;

namespace GalaxyGame.Service.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IPlayerMovementDataService>()
                    .ImplementedBy<PlayerMovementDataService>()
                    .LifeStyle.Transient
                );
        }
    }
}
