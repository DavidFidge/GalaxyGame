using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityFortuneVoronoi.Interfaces;

namespace UnityFortuneVoronoi.Components
{
    public class VoronoiEdge
    {
        internal bool Done = false;
        public Vector2 RightData, LeftData;
        public Vector2 VVertexA = Fortune.VVUnkown, VVertexB = Fortune.VVUnkown;

        public void AddVertex(Vector2 V)
        {
            if (VVertexA == Fortune.VVUnkown)
                VVertexA = V;
            else if (VVertexB == Fortune.VVUnkown)
                VVertexB = V;
            else throw new Exception("Tried to add third vertex!");
        }

        public bool IsInfinite
        {
            get { return VVertexA == Fortune.VVInfinite && VVertexB == Fortune.VVInfinite; }
        }

        public bool IsPartlyInfinite
        {
            get { return VVertexA == Fortune.VVInfinite || VVertexB == Fortune.VVInfinite; }
        }

        public Vector2 FixedPoint
        {
            get
            {
                if (IsInfinite)
                    return 0.5f * (LeftData + RightData);
                if (VVertexA != Fortune.VVInfinite)
                    return VVertexA;
                return VVertexB;
            }
        }

        public Vector2 DirectionVector2
        {
            get
            {
                if (!IsPartlyInfinite)
                    return (VVertexB - VVertexA) * (1.0f / (float) Math.Sqrt(Vector2.Distance(VVertexA, VVertexB)));
                if (LeftData[0] == RightData[0])
                {
                    if (LeftData[1] < RightData[1])
                        return new Vector2(-1, 0);
                    return new Vector2(1, 0);
                }
                Vector2 Erg = new Vector2(-(RightData[1] - LeftData[1]) / (RightData[0] - LeftData[0]), 1);
                if (RightData[0] < LeftData[0])
                    Erg = Erg * -1;
                Erg = Erg * (1.0f / Erg.magnitude);
                return Erg;
            }
        }

        public double Length
        {
            get
            {
                if (IsPartlyInfinite)
                    return double.PositiveInfinity;
                return Math.Sqrt(Vector2.Distance(VVertexA, VVertexB));
            }
        }

        public void Accept(IVisitor<VoronoiEdge> visitor)
        {
            visitor.Visit(this);
        }
    }
}