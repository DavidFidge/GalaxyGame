using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Core.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace GalaxyGame.Core.TestInfrastructure
{
    public class BaseUnitTest
    {
        protected IUnitOfWorkFactory _unitOfWorkFactory;
        protected IContext _context;
        protected IDateTimeProvider _dateTimeProvider;

        [SetUp]
        public virtual void Setup()
        {
            _dateTimeProvider = Substitute.For<IDateTimeProvider>();
            _dateTimeProvider.Now.Returns(new DateTime(2000, 1, 1));

            _unitOfWorkFactory = Substitute.For<IUnitOfWorkFactory>();
            _context = new FakeContext();

            _unitOfWorkFactory.Create().Returns(c =>
            {
                var unitOfWork = Substitute.For<IUnitOfWork>();
                unitOfWork.Context.Returns(_context);

                return unitOfWork;
            });
        }
    }
}