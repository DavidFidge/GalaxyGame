using System.Collections.Generic;
using System.Linq;
using BenTools.Mathematics;
using NUnit.Framework;
using UnityEngine;

using UnityHelpers;

namespace UnityTest
{
    [TestFixture]
    public class UnitTest2
    {
        [Test]
        public void TestMethod1()
        {
            var points = new List<Vector>();

            var random = new System.Random();

            for (var i = 0; i < 50; i++)
            {
                points.Add(new Vector(
                    random.Next(1000),
                    random.Next(1000))
                    );
            }

            var graph = Fortune.ComputeVoronoiGraph(points);

            int bigCount = 0;
            int smallCount = 0;

            foreach (var vector2 in graph.Edges)
            {

            }

        }

        private void Constrain(ref Vector2 v)
        {
            if (v.x < 0)
                v.x = 0;
            if (v.x > 1000f)
                v.x = 1000f;

            if (v.y < 0)
                v.y = 0;
            if (v.y > 1000f)
                v.y = 1000f;

        }
    }
}
