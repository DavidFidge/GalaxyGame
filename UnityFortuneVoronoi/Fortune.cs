using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityFortuneVoronoi.Collections;
using UnityFortuneVoronoi.Components;

namespace UnityFortuneVoronoi
{
    // VoronoiVertex or VoronoiDataPoint are represented as Vector2

    public abstract class Fortune
    {
        public static readonly Vector2 VVInfinite = new Vector2(float.PositiveInfinity, float.PositiveInfinity);
        public static readonly Vector2 VVUnkown = new Vector2(float.NaN, float.NaN);

        internal static double ParabolicCut(double x1, double y1, double x2, double y2, double ys)
        {
            if (Math.Abs(x1 - x2) < 1e-10 && Math.Abs(y1 - y2) < 1e-10)
            {
                throw new Exception("Identical datapoints are not allowed!");
            }

            if (Math.Abs(y1 - ys) < 1e-10 && Math.Abs(y2 - ys) < 1e-10)
                return (x1 + x2) / 2;
            if (Math.Abs(y1 - ys) < 1e-10)
                return x1;
            if (Math.Abs(y2 - ys) < 1e-10)
                return x2;
            double a1 = 1 / (2 * (y1 - ys));
            double a2 = 1 / (2 * (y2 - ys));
            if (Math.Abs(a1 - a2) < 1e-10)
                return (x1 + x2) / 2;
            double xs1 = 0.5 / (2 * a1 - 2 * a2) * (4 * a1 * x1 - 4 * a2 * x2 + 2 * Math.Sqrt(-8 * a1 * x1 * a2 * x2 - 2 * a1 * y1 + 2 * a1 * y2 + 4 * a1 * a2 * x2 * x2 + 2 * a2 * y1 + 4 * a2 * a1 * x1 * x1 - 2 * a2 * y2));
            double xs2 = 0.5 / (2 * a1 - 2 * a2) * (4 * a1 * x1 - 4 * a2 * x2 - 2 * Math.Sqrt(-8 * a1 * x1 * a2 * x2 - 2 * a1 * y1 + 2 * a1 * y2 + 4 * a1 * a2 * x2 * x2 + 2 * a2 * y1 + 4 * a2 * a1 * x1 * x1 - 2 * a2 * y2));
            xs1 = Math.Round(xs1, 10);
            xs2 = Math.Round(xs2, 10);
            if (xs1 > xs2)
            {
                double h = xs1;
                xs1 = xs2;
                xs2 = h;
            }
            if (y1 >= y2)
                return xs2;
            return xs1;
        }

        internal static Vector2 CircumCircleCenter(Vector2 A, Vector2 B, Vector2 C)
        {
            if (A == B || B == C || A == C)
                throw new Exception("Need three different points!");
            double tx = (A[0] + C[0]) / 2;
            double ty = (A[1] + C[1]) / 2;

            double vx = (B[0] + C[0]) / 2;
            double vy = (B[1] + C[1]) / 2;

            double ux, uy, wx, wy;

            if (A[0] == C[0])
            {
                ux = 1;
                uy = 0;
            }
            else
            {
                ux = (C[1] - A[1]) / (A[0] - C[0]);
                uy = 1;
            }

            if (B[0] == C[0])
            {
                wx = -1;
                wy = 0;
            }
            else
            {
                wx = (B[1] - C[1]) / (B[0] - C[0]);
                wy = -1;
            }

            double alpha = (wy * (vx - tx) - wx * (vy - ty)) / (ux * wy - wx * uy);

            return new Vector2((float) (tx + alpha * ux), (float) (ty + alpha * uy));
        }

        public static VoronoiGraph ComputeVoronoiGraph(IEnumerable Datapoints)
        {
            BinaryPriorityQueue PQ = new BinaryPriorityQueue();
            Hashtable CurrentCircles = new Hashtable();
            VoronoiGraph VG = new VoronoiGraph();
            VNode RootNode = null;
            foreach (Vector2 V in Datapoints)
            {
                PQ.Push(new VDataEvent(V));
            }
            while (PQ.Count > 0)
            {
                VEvent VE = PQ.Pop() as VEvent;
                VDataNode[] CircleCheckList;
                if (VE is VDataEvent)
                {
                    RootNode = VNode.ProcessDataEvent(VE as VDataEvent, RootNode, VG, VE.Y, out CircleCheckList);
                }
                else if (VE is VCircleEvent)
                {
                    CurrentCircles.Remove(((VCircleEvent) VE).NodeN);
                    if (!((VCircleEvent) VE).Valid)
                        continue;
                    RootNode = VNode.ProcessCircleEvent(VE as VCircleEvent, RootNode, VG, VE.Y, out CircleCheckList);
                }
                else throw new Exception("Got event of type " + VE.GetType() + "!");
                foreach (VDataNode VD in CircleCheckList)
                {
                    if (CurrentCircles.ContainsKey(VD))
                    {
                        ((VCircleEvent) CurrentCircles[VD]).Valid = false;
                        CurrentCircles.Remove(VD);
                    }
                    VCircleEvent VCE = VNode.CircleCheckDataNode(VD, VE.Y);
                    if (VCE != null)
                    {
                        PQ.Push(VCE);
                        CurrentCircles[VD] = VCE;
                    }
                }
                if (VE is VDataEvent)
                {
                    Vector2 DP = ((VDataEvent) VE).DataPoint;
                    foreach (VCircleEvent VCE in CurrentCircles.Values)
                    {
                        if (MathTools.Dist(DP[0], DP[1], VCE.Center[0], VCE.Center[1]) < VCE.Y - VCE.Center[1] && Math.Abs(MathTools.Dist(DP[0], DP[1], VCE.Center[0], VCE.Center[1]) - (VCE.Y - VCE.Center[1])) > 1e-10)
                            VCE.Valid = false;
                    }
                }
            }
            VNode.CleanUpTree(RootNode);
            foreach (VoronoiEdge VE in VG.Edges)
            {
                if (VE.Done)
                    continue;
                if (VE.VVertexB == VVUnkown)
                {
                    VE.AddVertex(VVInfinite);
                    if (Math.Abs(VE.LeftData[1] - VE.RightData[1]) < 1e-10 && VE.LeftData[0] < VE.RightData[0])
                    {
                        Vector2 T = VE.LeftData;
                        VE.LeftData = VE.RightData;
                        VE.RightData = T;
                    }
                }
            }

            ArrayList MinuteEdges = new ArrayList();
            foreach (VoronoiEdge VE in VG.Edges)
            {
                if (!VE.IsPartlyInfinite && VE.VVertexA.Equals(VE.VVertexB))
                {
                    MinuteEdges.Add(VE);
                    // prevent rounding errors from expanding to holes
                    foreach (VoronoiEdge VE2 in VG.Edges)
                    {
                        if (VE2.VVertexA.Equals(VE.VVertexA))
                            VE2.VVertexA = VE.VVertexA;
                        if (VE2.VVertexB.Equals(VE.VVertexA))
                            VE2.VVertexB = VE.VVertexA;
                    }
                }
            }
            foreach (VoronoiEdge VE in MinuteEdges)
                VG.Edges.Remove(VE);

            return VG;
        }

        public static VoronoiGraph FilterVG(VoronoiGraph VG, double minLeftRightDist)
        {
            VoronoiGraph VGErg = new VoronoiGraph();
            foreach (VoronoiEdge VE in VG.Edges)
            {
                if (Math.Sqrt(Vector2.Distance(VE.LeftData, VE.RightData)) >= minLeftRightDist)
                    VGErg.Edges.Add(VE);
            }
            foreach (VoronoiEdge VE in VGErg.Edges)
            {
                VGErg.Vertizes.Add(VE.VVertexA);
                VGErg.Vertizes.Add(VE.VVertexB);
            }
            return VGErg;
        }
    }
}