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
    public class ProceduralTextureTest : MonoBehaviour, IGenerator
    {
        public void Start()
        {
            Generate();
        }

        public void Generate()
        {



            var texture2D = new Texture2D(1000, 1000);

            texture2D.DrawLine(10,10,500,500, Color.red);
            texture2D.DrawLine(500, 500, 999, 10, Color.red);

            texture2D.Apply();

            renderer.material.mainTexture = texture2D;
        }
    

    }
}