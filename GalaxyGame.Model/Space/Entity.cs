using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GalaxyGame.Core.Interfaces;

namespace GalaxyGame.Model.Space
{
    public class Entity : IEntity
    {
        public Entity()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public virtual DateTime Modified  { get; set; }
        public virtual string Username  { get; set; }
    }
}
