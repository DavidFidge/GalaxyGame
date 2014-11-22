using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityFortuneVoronoi;
using UnityHelpers;

namespace UnityTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var points = new List<Vector2>();

            var random = new System.Random();

            for (var i = 0; i < 50; i++)
            {
                points.Add(new Vector2(
                    random.Next(1000),
                    random.Next(1000))
                    );
            }
            points = points.OrderBy(p => p.x).ThenBy(p => p.y).ToList();

            var graph = Fortune.ComputeVoronoiGraph(points);

            foreach (var vector2 in graph.Edges.Select(e => e.LeftData))
            {
                Assert.True(vector2.x >= 0 && vector2.y >= 0);
            }

            foreach (var vector2 in graph.Edges.Select(e => e.RightData))
            {
                Assert.True(vector2.x >= 0 && vector2.y >= 0);
            }

            int bigCount = 0;
            int smallCount = 0;

            foreach (var vector2 in graph.Edges)//graph.Edges.Select(e => e.VVertexA).Concat(graph.Edges.Select(e => e.VVertexB)))
            {
                Constrain(ref vector2.VVertexA);


                //if (vector2.x > 1000f)
                //    bigCount++;
                //if (vector2.y > 1000f)
                //    bigCount++;
                //if (vector2.x > 1000f)
                //    bigCount++;
                //if (vector2.y > 1000f)
                //    bigCount++;

                //if (vector2.x < 0f)
                //    smallCount++;
                //if (vector2.y < 0f)
                //    smallCount++;
                //if (vector2.x < 0f)
                //    smallCount++;
                //if (vector2.y < 0f)
                //    smallCount++;
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
