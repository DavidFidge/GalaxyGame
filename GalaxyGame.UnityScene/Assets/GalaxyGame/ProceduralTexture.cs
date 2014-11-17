using System;
using System.Collections.Generic;
using System.Linq;
using ProceduralToolkit;
using UnityEngine;

namespace Assets.GalaxyGame
{
    [RequireComponent(typeof(Renderer))]
    public class ProceduralTexture : MonoBehaviour, IGenerator
    {
        public void Start()
        {
            Generate();
        }

        public void Generate()
        {
            var texture2D = new Texture2D(1000, 1000);

            var colours = new Color[1000 * 1000];

            for (int i = 0; i < colours.Length; i++)
            {
                colours[i] = RandomE.color;
            }

            texture2D.SetPixels(colours);

            texture2D.Apply();

            renderer.material.mainTexture = texture2D;
        }
    }
}