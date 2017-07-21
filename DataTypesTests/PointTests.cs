﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using BRobot;

namespace DataTypesTests
{
    [TestClass]
    public class PointTests : DataTypesTests
    {
        [TestMethod]
        public void Point_CompareDirections()
        {
            Point a = new Point(1, 0, 0);

            Point b = new Point(1, 1, 0);
            Assert.AreEqual(0, Point.CompareDirections(a, b));  // nothing

            b = new Point(1, 0, 0);
            Assert.AreEqual(1, Point.CompareDirections(a, b));  // parallel

            b = new Point(5, 0, 0);
            Assert.AreEqual(1, Point.CompareDirections(a, b));  // parallel

            b = new Point(10, 0, 0);
            Assert.AreEqual(1, Point.CompareDirections(a, b));  // parallel

            b = new Point(0, 1, 0);
            Assert.AreEqual(2, Point.CompareDirections(a, b));  // orthogonal

            b = new Point(0, 0, 1);
            Assert.AreEqual(2, Point.CompareDirections(a, b));  // orthogonal

            b = new Point(0, -1, 0);
            Assert.AreEqual(2, Point.CompareDirections(a, b));  // orthogonal

            b = new Point(0, 0, -1);
            Assert.AreEqual(2, Point.CompareDirections(a, b));  // orthogonal

            b = new Point(-1, 0, 0);
            Assert.AreEqual(3, Point.CompareDirections(a, b));  // opposed

            b = new Point(-5, 0, 0);
            Assert.AreEqual(3, Point.CompareDirections(a, b));  // opposed

            b = new Point(-10, 0, 0);
            Assert.AreEqual(3, Point.CompareDirections(a, b));  // opposed

            a = new Point(Random(-100, 100), Random(-100, 100), Random(-100, 100));
            b = new Point(5 * a.X, 5 * a.Y, 5 * a.Z);
            Trace.WriteLine(a);
            Trace.WriteLine(b);
            Assert.AreEqual(1, Point.CompareDirections(a, b));  // parallel

            b = new Point(-a.X, -a.Y, -a.Z);
            Trace.WriteLine(a);
            Trace.WriteLine(b);
            Assert.AreEqual(3, Point.CompareDirections(a, b));  // opposed

        }

    }
}