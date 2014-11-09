using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyGame.Core.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime Modified { get; set; }
        string Username { get; set; }
    }
}