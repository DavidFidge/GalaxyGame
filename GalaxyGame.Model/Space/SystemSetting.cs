using System;
using System.Collections.Generic;

namespace GalaxyGame.Model.Space
{
    public class SystemSetting : Entity
    {
        public SystemSetting()
        {
        }

        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
    }
}
