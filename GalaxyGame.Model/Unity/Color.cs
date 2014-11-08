using System;
using System.Collections.Generic;
using GalaxyGame.Model.Space;

namespace GalaxyGame.Model.Unity
{
    // Wrapper to turn struct Unity Color to a class Color so that it can be recognised as a 
    // Complex Type in Entity Framework
    public class Color
    {
        public UnityEngine.Color Value;

        public float A { get { return Value.a; } set { Value.a = value; } }
        public float R { get { return Value.r; } set { Value.r = value; } }
        public float G { get { return Value.g; } set { Value.g = value; } }
        public float B { get { return Value.b; } set { Value.b = value; } }

        public static Color operator +(Color v1, Color v2)
        {
            if (v1 == null || v2 == null)
                throw new ArgumentNullException();

            return new Color(v1.Value + v2.Value);
        }

        public static Color operator -(Color v1, Color v2)
        {
            if (v1 == null || v2 == null)
                throw new ArgumentNullException();

            return new Color(v1.Value - v2.Value);
        }

        public static Color operator *(Color v1, float f)
        {
            if (v1 == null)
                throw new ArgumentNullException();

            return new Color(v1.Value * f);
        }

        public static Color operator /(Color v1, float f)
        {
            if (v1 == null)
                throw new ArgumentNullException();

            if (f == 0)
                throw new DivideByZeroException();

            return new Color(v1.Value / f);
        }

        public static bool operator ==(Color v1, Color v2)
        {
            if (ReferenceEquals(v1, null) && ReferenceEquals(v2, null))
                return true;

            if (ReferenceEquals(v1, null) || ReferenceEquals(v2, null))
                return false;

            return v1.Value == v2.Value;
        }

        public static bool operator !=(Color v1, Color v2)
        {
            return !(v1 == v2);
        }

        public override bool Equals(object obj)
        {
            var v2 = obj as Color;

            if (obj == null)
                return false;

            return v2 == this;
        }

        public override int GetHashCode()
        {
            return A.GetHashCode() + R.GetHashCode() + G.GetHashCode() + B.GetHashCode();
        }

        public Color()
        {
            Value = UnityEngine.Color.black;
        }

        public Color(float a, float r, float g, float b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public Color(UnityEngine.Color color)
        {
            Value = color;
        }

        public Color(Color color)
        {
            Value = color.Value;
        }

        public static Color Black
        {
            get { return new Color(); }
        }

        public static Color White
        {
            get { return new Color(UnityEngine.Color.white); }
        }
    }
}
