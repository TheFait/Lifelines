using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Graph3D
{
    public class DataPoint
    {
        private float x;
        private float y;
        private float z;
        private Color color;
        private GameObject visual;

        public DataPoint(float x, float y, float z, Vector3 scale, Color color, GameObject visual = null)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.color = color;

            if (visual == null)
            {
                this.visual = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                this.visual.GetComponent<Renderer>().material.color = color;
                this.visual.transform.localScale = scale * .2f;
            }
        }

        public float X { get { return x; } }
        public float Y { get { return y; } }
        public float Z { get { return z; } }
        public Color Color { get { return color; } }
        public Vector3 Position { get { return new Vector3(x, y, z); } }
        public GameObject Visual { get { return visual; } }
    }

}