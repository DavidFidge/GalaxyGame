using System;
using System.Collections.Generic;
using GalaxyGame.Model.Space;

namespace GalaxyGame.Model.Unity
{
    public class Vector2
    {
        public UnityEngine.Vector2 Value;

        public float X { get { return Value.x; } set { Value.x = value; } }
        public float Y { get { return Value.y; } set { Value.y = value; } }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            if (v1 == null || v2 == null)
                throw new ArgumentNullException();

            return new Vector2(v1.Value + v2.Value);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            if (v1 == null || v2 == null)
                throw new ArgumentNullException();

            return new Vector2(v1.Value - v2.Value);
        }

        public static Vector2 operator *(Vector2 v1, float f)
        {
            if (v1 == null)
                throw new ArgumentNullException();

            return new Vector2(v1.Value * f);
        }

        public static Vector2 operator /(Vector2 v1, float f)
        {
            if (v1 == null)
                throw new ArgumentNullException();

            if (f == 0)
                throw new DivideByZeroException();

            return new Vector2(v1.Value / f);
        }

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            if (ReferenceEquals(v1, null) && ReferenceEquals(v2, null))
                return true;

            if (ReferenceEquals(v1, null) || ReferenceEquals(v2, null))
                return false;

            return v1.Value == v2.Value;
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return !(v1 == v2);
        }

        public override bool Equals(object obj)
        {
            var v2 = obj as Vector2;

            if (obj == null)
                return false;

            return v2 == this;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public Vector2()
        {
            Value = UnityEngine.Vector2.zero;
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2(float value)
        {
            X = value;
            Y = value;
        }

        public Vector2(UnityEngine.Vector2 Vector2)
        {
            Value = Vector2;
        }

        public Vector2(Vector2 Vector2)
        {
            Value = Vector2.Value;
        }
    }
}
