﻿using UnityEngine;

namespace ProceduralToolkit.Examples.Primitives
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class Prism : MonoBehaviour
    {
        public float radius = 1f;
        public int segments = 16;
        public float height = 2f;

        public void Start()
        {
            GetComponent<MeshFilter>().mesh = MeshE.Prism(radius, segments, height);
        }
    }
}