using System;
using System.Collections.Generic;
using System.Linq;
using ProceduralToolkit;
using UnityEngine;

namespace Assets.GalaxyGame
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class ProceduralSphere : MonoBehaviour, IGenerator
    {
        public float Radius = 1f;
        public int LongitudeSegments = 16;
        public int LatitudeSegments = 16;

        public void Start()
        {
            Generate();
        }

        public void Generate()
        {
            GetComponent<MeshFilter>().mesh = MeshE.Sphere(Radius, LongitudeSegments, LatitudeSegments);
        }
    }
}