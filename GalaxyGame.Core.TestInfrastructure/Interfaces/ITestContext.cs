using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GalaxyGame.Core.Interfaces;

namespace GalaxyGame.Core.TestInfrastructure.Interfaces
{
    public interface ITestContext : IContext
    {
        void DeleteDatabase();
    }
}
