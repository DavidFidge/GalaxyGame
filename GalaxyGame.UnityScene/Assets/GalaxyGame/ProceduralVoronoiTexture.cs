using System;
using System.Collections.Generic;
using System.Linq;
using Delaunay;
using ProceduralToolkit;
using UnityEngine;

namespace Assets.GalaxyGame
{
    [RequireComponent(typeof(Renderer))]
    public class ProceduralVoronoiTexture : MonoBehaviour, IGenerator
    {
        public void Start()
        {
            Generate();
        }

        public void Generate()
        {
           var colors = new List<uint>();
            var points = new List<Vector2>();

            for (int i = 0; i < 50; i++)
            {
                var colour = RandomE.color.ToUInt();

                Debug.Log("site color" + colour.ToString());
                Debug.Log("site color" + colour.ToString());
                Debug.Log("site color back" + colour.ToString());

                colors.Add(colour);
                points.Add(new Vector2(
                    UnityEngine.Random.Range(0, 1000),
                    UnityEngine.Random.Range(0, 1000))
                );
            }
            var v = new Delaunay.Voronoi(points, colors, new Rect(0, 0, 1000, 1000));

            var texture2D = new Texture2D(1000, 1000);

            var colours = new Color[1000 * 1000];

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    var site = v.SiteForPoint(new Vector2(i, j));

                    colours[i * j] = ColorExtensions.FromUInt(site.color);
                }
            }

            texture2D.SetPixels(colours);

            texture2D.Apply();

            renderer.material.mainTexture = texture2D;
        }


    }
}