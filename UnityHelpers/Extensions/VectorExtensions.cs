using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityHelpers.Extensions
{
    public static class VectorExtensions
    {
        public static Vector2 Vector2FromVector3(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.y);
        }

        public static Vector3 Vector3FromVector2(this Vector2 vector2, float z = 0f)
        {
            return new Vector3(vector2.x, vector2.y, z);
        }

        public static Vector4 Vector4FromVector3(this Vector3 vector3, float w = 0f)
        {
            return new Vector4(vector3.x, vector3.y, vector3.z, w);
        }

        public static Vector3 Vector3FromVector4(this Vector4 vector4)
        {
            return new Vector3(vector4.x, vector4.y, vector4.z);
        }

        public static Vector2 RectLeftTop(this Rect r)
        {
            return new Vector2(r.xMin, r.yMax);
        }

        public static Vector2 RectRightTop(this Rect r)
        {
            return new Vector2(r.xMax, r.yMax);
        }

        public static Vector2 RectRightBottom(this Rect r)
        {
            return new Vector2(r.xMax, r.yMin);
        }

        public static Vector2 RectLeftBottom(this Rect r)
        {
            return new Vector2(r.xMin, r.yMin);
        }
    }
}