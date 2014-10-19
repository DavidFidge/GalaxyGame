using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MassTransit;
using MassTransit.Log4NetIntegration;

namespace GalaxyGame.Service.Installers
{
    public class BusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var bus = ServiceBusFactory.New(sbc =>
            {
                //other configuration options
                sbc.UseMsmq(mc => { mc.VerifyMsmqConfiguration(); });

                sbc.UseLog4Net();

                sbc.ReceiveFrom("msmq://localhost/galaxygame");

                //this will find all of the consumers in the container and
                //register them with the bus.
                sbc.Subscribe(x => x.LoadFrom(container));
            });

            //now we add the bus
            container.Register(Component.For<IServiceBus>().Instance(bus));
        }
    }
}