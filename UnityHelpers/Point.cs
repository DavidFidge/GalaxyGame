using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityHelpers
{
    public struct Point
    {
        public int x;
        public int y;

        public Point(int xx, int yy)
        {
            x = xx;
            y = yy;
        }

        public static Point operator -(Point a)
        {
            return new Point(-a.x, -a.y);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y);
        }

        public static bool operator !=(Point lhs, Point rhs)
        {
            return !(lhs == rhs);
        }

        public static Point operator *(Point a, Point b)
        {
            return new Point(a.x * b.x, a.y * b.y);
        }

        public static Point operator *(int d, Point a)
        {
            return new Point(a.x * d, a.y * d);
        }

        public static Point operator *(Point a, int d)
        {
            return new Point(a.x * d, a.y * d);
        }

        public static Point operator /(Point a, int d)
        {
            return new Point(a.x / d, a.y / d);
        }

        public static Point operator /(Point a, Point b)
        {
            return new Point(a.x / b.x, a.y / b.y);
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }

        public static bool operator ==(Point lhs, Point rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }

        public override int GetHashCode()
        {
            return x ^ y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != typeof(Point))
                return false;

            var p = (Point) obj;

            return x == p.x && y == p.y;
        }
    }
}