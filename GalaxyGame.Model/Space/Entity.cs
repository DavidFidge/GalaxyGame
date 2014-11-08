using System;
using System.Collections.Generic;
using GalaxyGame.Core.Interfaces;

namespace GalaxyGame.Model.Space
{
    public class Entity : IEntity
    {
        public Entity()
        {
        }

        public Guid Id { get; set; }
        public virtual DateTime Modified  { get; set; }
        public virtual string Username  { get; set; }
    }
}
