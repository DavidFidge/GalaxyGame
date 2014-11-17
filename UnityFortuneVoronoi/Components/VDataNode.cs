using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityFortuneVoronoi.Components
{
    internal class VDataNode : VNode
    {
        public VDataNode(Vector2 DP)
        {
            this.DataPoint = DP;
        }

        public Vector2 DataPoint;
    }
}