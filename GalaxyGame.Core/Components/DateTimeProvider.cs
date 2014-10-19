using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Core.Interfaces;

namespace GalaxyGame.Core.Components
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}