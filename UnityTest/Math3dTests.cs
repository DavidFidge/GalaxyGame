using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityHelpers;

namespace UnityTest
{
    [TestFixture]
    public class Math3dTests
    {
        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        public void LineLineIntersectionPoints_Test_Basic_Intersection(int sign)
        {
            var point1 = new Vector2(0, 0);
            var point2 = new Vector2(50 * sign, 50 * sign);

            var point3 = new Vector2(0, 50 * sign);
            var point4 = new Vector2(50 * sign, 0);

            var output = new Vector2();

            var success = Math3d.LineLineIntersectionPoints(out output, point1, point2, point3, point4);

            Assert.True(success);
            Assert.AreEqual(output, new Vector2(25 * sign, 25 * sign));
        }

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        public void LineLineIntersectionPoints_Test_No_Diagonal_Intersection(int sign)
        {
            var point1 = new Vector2(0, 0);
            var point2 = new Vector2(50 * sign, 50 * sign);

            var point3 = new Vector2(1 * sign, 1 * sign);
            var point4 = new Vector2(51 * sign, 51 * sign);

            var output = new Vector2();

            var success = Math3d.LineLineIntersectionPoints(out output, point1, point2, point3, point4);

            Assert.False(success);
            Assert.AreEqual(output, Vector2.zero);
        }

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        public void LineLineIntersectionPoints_Test_No_Y_Intersection(int sign)
        {
            var point1 = new Vector2(0, 0);
            var point2 = new Vector2(0, 50 * sign);

            var point3 = new Vector2(1 * sign, 0);
            var point4 = new Vector2(1 * sign, 50 * sign);

            var output = new Vector2();

            var success = Math3d.LineLineIntersectionPoints(out output, point1, point2, point3, point4);

            Assert.False(success);
            Assert.AreEqual(output, Vector2.zero);
        }

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        public void LineLineIntersectionPoints_Test_No_X_Intersection(int sign)
        {
            var point1 = new Vector2(0, 0);
            var point2 = new Vector2(50 * sign, 0);

            var point3 = new Vector2(0, 1 * sign);
            var point4 = new Vector2(50 * sign, 1 * sign);

            var output = new Vector2();

            var success = Math3d.LineLineIntersectionPoints(out output, point1, point2, point3, point4);

            Assert.False(success);
            Assert.AreEqual(output, Vector2.zero);
        }

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        public void LineLineIntersectionPoints_Test_Corner_Intersection(int sign)
        {
            var point1 = new Vector2(0, 0);
            var point2 = new Vector2(50 * sign, 50 * sign);

            var point3 = new Vector2(50 * sign, 50 * sign);
            var point4 = new Vector2(100 * sign, 0);

            var output = new Vector2();

            var success = Math3d.LineLineIntersectionPoints(out output, point1, point2, point3, point4);

            Assert.True(success);
            Assert.AreEqual(output, new Vector2(50 * sign, 50 * sign));
        }

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        public void LineLineIntersectionPoints_Test_No_1_Pixel_Away_Intersection(int sign)
        {
            var point1 = new Vector2(0, 0);
            var point2 = new Vector2(50 * sign, 50 * sign);

            var point3 = new Vector2(51 * sign, 0);
            var point4 = new Vector2(51 * sign, 100 * sign);

            var output = new Vector2();

            var success = Math3d.LineLineIntersectionPoints(out output, point1, point2, point3, point4);

            Assert.False(success);
            Assert.AreEqual(output, Vector2.zero);
        }
    }
}