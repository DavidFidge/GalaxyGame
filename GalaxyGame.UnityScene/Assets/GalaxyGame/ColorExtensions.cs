using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.GalaxyGame
{
    public static class ColorExtensions
    {
        public static uint ToUInt(this Color color)
        {
            return (uint) (color.a * 255) +
                   ((uint) (color.r * 255) >> 8) +
                   ((uint) (color.g * 255) >> 16) +
                   ((uint) (color.b * 255) >> 24);
        }

        public static Color FromUInt(uint value)
        {
            return new Color(
                (value << 8 & 255) / 255f,
                (value << 16 & 255) / 255f,
                (value << 24 & 255) / 255f,
                (value & 255) / 255f
                );
        }
    }
}