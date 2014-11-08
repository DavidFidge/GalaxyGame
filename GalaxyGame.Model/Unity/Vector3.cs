using System;
using System.Collections.Generic;
using GalaxyGame.Model.Space;

namespace GalaxyGame.Model.Unity
{
    // Wrapper to turn struct Unity vector 3 to a class vector 3 so that it can be recognised as a 
    // Complex Type in Entity Framework
    public class Vector3
    {
        public UnityEngine.Vector3 Value;

        public float X { get { return Value.x; } set { Value.x = value; } }
        public float Y { get { return Value.y; } set { Value.y = value; } }
        public float Z { get { return Value.z; } set { Value.z = value; } }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            if (v1 == null || v2 == null)
                throw new ArgumentNullException();

            return new Vector3(v1.Value + v2.Value);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            if (v1 == null || v2 == null)
                throw new ArgumentNullException();

            return new Vector3(v1.Value - v2.Value);
        }

        public static Vector3 operator *(Vector3 v1, float f)
        {
            if (v1 == null)
                throw new ArgumentNullException();

            return new Vector3(v1.Value * f);
        }

        public static Vector3 operator /(Vector3 v1, float f)
        {
            if (v1 == null)
                throw new ArgumentNullException();

            if (f == 0)
                throw new DivideByZeroException();

            return new Vector3(v1.Value / f);
        }

        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            if (ReferenceEquals(v1, null) && ReferenceEquals(v2, null))
                return true;

            if (ReferenceEquals(v1, null) || ReferenceEquals(v2, null))
                return false;

            return v1.Value == v2.Value;
        }

        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            return !(v1 == v2);
        }

        public override bool Equals(object obj)
        {
            var v2 = obj as Vector3;

            if (obj == null)
                return false;

            return v2 == this;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }

        public Vector3()
        {
            Value = UnityEngine.Vector3.zero;
        }

        public Vector3(float value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(UnityEngine.Vector3 vector3)
        {
            Value = vector3;
        }

        public Vector3(Vector3 vector3)
        {
            Value = vector3.Value;
        }
    }
}
