using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityFortuneVoronoi.Components;

namespace UnityFortuneVoronoi
{
    internal class VCircleEvent : VEvent
    {
        public VDataNode NodeN, NodeL, NodeR;
        public Vector2 Center;

        public override double Y
        {
            get { return Math.Round(Center[1] + MathTools.Dist(NodeN.DataPoint[0], NodeN.DataPoint[1], Center[0], Center[1]), 10); }
        }

        public override double X
        {
            get { return Center[0]; }
        }

        public bool Valid = true;
    }
}