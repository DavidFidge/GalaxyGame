using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyGame.Core.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}