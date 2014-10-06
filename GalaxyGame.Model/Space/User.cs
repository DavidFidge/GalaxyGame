using System;
using System.Collections.Generic;

namespace GalaxyGame.Model.Space
{
    public class User : Entity
    {
        public User()
        {
        }

        public virtual string EmailAddress  { get; set; }

        public Guid PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}
