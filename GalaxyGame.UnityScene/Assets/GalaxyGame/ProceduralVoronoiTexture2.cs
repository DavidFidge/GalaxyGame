using System;
using System.Collections.Generic;
using System.Linq;
using BenTools.Mathematics;
using UnityEngine;

using UnityHelpers.Extensions;
using Random = UnityEngine.Random;

namespace Assets.GalaxyGame
{
    [RequireComponent(typeof(Renderer))]
    public class ProceduralVoronoiTexture2 : MonoBehaviour, IGenerator
    {
        public void Start()
        {
            Generate();
        }

        public void Generate()
        {
            var points = new List<Vector>();

            for (var i = 0; i < 5; i++)
            {
                points.Add(new Vector(
                    (double)Random.Range(0, 1000),
                    (double)Random.Range(0, 1000))
                    );
            }

            var v = Fortune.ComputeVoronoiGraph(points);

            var texture2D = new Texture2D(1000, 1000);

            var drawLineVisitor = new DrawLineVisitor(texture2D, Color.red);

            foreach (var edge in v.Edges)
            {
                edge.Accept(drawLineVisitor);
            }

            foreach (var vector2 in v.Vertizes)
            {
                texture2D.DrawPoint(vector2.Vector2, 2, Color.black);
            }

            foreach (var vector2 in points)
            {
                texture2D.DrawPoint(vector2.Vector2, 1, Color.blue);
            }


            foreach (var edge in v.Edges)
            {
                texture2D.DrawPoint(edge.FixedPoint.Vector2, 1, Color.blue);
            }

            texture2D.Apply();

            renderer.material.mainTexture = texture2D;
        }
    }

    public class DrawLineVisitor : VoronoiEdge.IVisitor<VoronoiEdge>
    {
        private readonly Texture2D _texture;
        private readonly Color _color;

        public DrawLineVisitor(Texture2D texture, Color color)
        {
            _texture = texture;
            _color = color;
        }

        public void Visit(VoronoiEdge edge)
        {
            //_texture.DrawLine(edge.LeftData.Vector2, edge.RightData.Vector2, _color);
            if (!edge.IsPartlyInfinite)
                _texture.DrawLine(Constrain(edge.VVertexA.Vector2), Constrain(edge.VVertexB.Vector2), _color);
            //_texture.DrawLine(edge.FixedPoint.Vector2, edge.RightData.Vector2, _color);
        }

        private Vector2 Constrain(Vector2 v)
        {
            //if (v.x < 0)
            //    v.x = 0;
            //if (v.x > 1000f)
            //    v.x = 1000f;

            //if (v.y < 0)
            //    v.y = 0;
            //if (v.y > 1000f)
            //    v.y = 1000f;

            return v;
        }
    }

    //public class DrawLineVisitor2 : IVisitor<VoronoiEdge>
    //{
    //    private readonly Texture2D _texture;
    //    private readonly Color _color;

    //    public DrawLineVisitor2(Texture2D texture, Color color)
    //    {
    //        _texture = texture;
    //        _color = color;
    //    }

    //    public void Visit(VoronoiEdge edge)
    //    {
    //        Constrain(ref edge.VVertexA);
    //        Constrain(ref edge.VVertexB);

    //        _texture.DrawLine(edge.VVertexA, edge.VVertexB, _color);
    //    }

    //    private void Constrain(ref Vector2 v)
    //    {
    //        if (v.x < 0)
    //            v.x = 0;
    //        if (v.x > 1000f)
    //            v.x = 1000f;

    //        if (v.y < 0)
    //            v.y = 0;
    //        if (v.y > 1000f)
    //            v.y = 1000f;

    //    }

    //}
}