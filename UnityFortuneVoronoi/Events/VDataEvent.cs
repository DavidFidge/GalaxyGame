using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityFortuneVoronoi
{
    internal class VDataEvent : VEvent
    {
        public Vector2 DataPoint;

        public VDataEvent(Vector2 DP)
        {
            this.DataPoint = DP;
        }

        public override double Y
        {
            get { return DataPoint[1]; }
        }

        public override double X
        {
            get { return DataPoint[0]; }
        }
    }
}