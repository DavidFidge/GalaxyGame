using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using Castle.Facilities.Logging;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using GalaxyGame.Core.Interfaces;
using GalaxyGame.Core.TestInfrastructure.Installers;
using GalaxyGame.Core.TestInfrastructure.Interfaces;
using GalaxyGame.DataLayer.Components;
using GalaxyGame.DataLayer.Installers;
using GalaxyGame.DataLayer.Interfaces;
using NUnit.Framework;

namespace GalaxyGame.Core.TestInfrastructure.Base
{
    public class BaseIntegrationTest : IDisposable
    {
        protected WindsorContainer _container;
        private IUnitOfWorkFactory _unitOfWorkFactory;

        public IUnitOfWorkFactory UnitOfWorkFactory
        {
            get
            {
                _unitOfWorkFactory = _unitOfWorkFactory ?? _container.Resolve<IUnitOfWorkFactory>("TestUnitOfWorkFactory");
                return _unitOfWorkFactory;
            }
        }

        [SetUp]
        public virtual void Setup()
        {
            _container = new WindsorContainer();
            _container.AddFacility<TypedFactoryFacility>();
            _container.AddFacility<LoggingFacility>(f => f.UseNLog());

            _container.Install(new IntegrationTestInstaller());
            _container.Install(new DataLayerInstaller());

            _container.Register(
                Component.For<IUnitOfWorkFactory>()
                    .ImplementedBy<UnitOfWorkFactory>()
                    .Named("TestUnitOfWorkFactory")
                    .LifeStyle.Transient);
        }

        [TearDown]
        public virtual void Teardown()
        {
            var testContext = _container.Resolve<ITestContext>();
            testContext.DeleteDatabase();
            _container.Release(testContext);

            Dispose();
        }

        public void Dispose()
        {
            if (_unitOfWorkFactory != null)
            {
                _unitOfWorkFactory.Dispose();
                _container.Release(_unitOfWorkFactory);
                _unitOfWorkFactory = null;
            }

            if (_container != null)
            {
                _container.Dispose();
                _container = null;
            }
        }
    }
}