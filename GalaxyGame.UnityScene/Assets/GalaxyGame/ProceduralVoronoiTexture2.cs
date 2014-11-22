using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityFortuneVoronoi;
using UnityFortuneVoronoi.Components;
using UnityFortuneVoronoi.Interfaces;
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
            var points = new List<Vector2>();

            for (var i = 0; i < 50; i++)
            {
                points.Add(new Vector2(
                    Random.Range(0, 1000),
                    Random.Range(0, 1000))
                    );
            }

            var v = Fortune.ComputeVoronoiGraph(points);

            var texture2D = new Texture2D(1000, 1000);

            var drawLineVisitor = new DrawLineVisitor2(texture2D, Color.red);

            foreach (var edge in v.Edges)
            {
                edge.Accept(drawLineVisitor);
            }

            texture2D.Apply();

            renderer.material.mainTexture = texture2D;
        }
    }

    public class DrawLineVisitor : IVisitor<VoronoiEdge>
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
            _texture.DrawLine(edge.LeftData, edge.RightData, _color);
        }
    }

    public class DrawLineVisitor2 : IVisitor<VoronoiEdge>
    {
        private readonly Texture2D _texture;
        private readonly Color _color;

        public DrawLineVisitor2(Texture2D texture, Color color)
        {
            _texture = texture;
            _color = color;
        }

        public void Visit(VoronoiEdge edge)
        {
            Constrain(ref edge.VVertexA);
            Constrain(ref edge.VVertexB);

            _texture.DrawLine(edge.VVertexA, edge.VVertexB, _color);
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