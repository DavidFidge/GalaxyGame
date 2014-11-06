using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace GalaxyGame.Core.Interfaces
{   
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime Modified { get; set; }
        string Username { get; set; }
    }
}
