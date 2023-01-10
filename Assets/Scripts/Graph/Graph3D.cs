using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Graph3D
{
    public class Graph3D : MonoBehaviour
    {
        // Visuals for the x, y, and z axes
        public GameObject xAxisVisual;
        public GameObject yAxisVisual;
        public GameObject zAxisVisual;

        // Length of the axes in world units
        public float xAxisLength = 10f;
        public float yAxisLength = 10f;
        public float zAxisLength = 10f;

        // Size used for the other dimensions of the axis. Used to set up 
        public float axisSize = .1f;

        // Prefab for the data points
        public GameObject dataPointPrefab;

        // Data for the graph
        private List<DataPoint> dataPoints = new List<DataPoint>();

        // Factory for creating data points
        private DataPointFactory dataPointFactory;

        // Use this for initialization
        void Start()
        {
            // Create default axis visuals if none are set
            if (xAxisVisual == null)
            {
                xAxisVisual = GameObject.CreatePrimitive(PrimitiveType.Cube);
                xAxisVisual.name = "X Axis";
            }
            if (yAxisVisual == null)
            {
                yAxisVisual = GameObject.CreatePrimitive(PrimitiveType.Cube);
                yAxisVisual.name = "Y Axis";
            }
            if (zAxisVisual == null)
            {
                zAxisVisual = GameObject.CreatePrimitive(PrimitiveType.Cube);
                zAxisVisual.name = "Z Axis";
            }

            // Set the parent of the axis visuals to the graph game object
            xAxisVisual.transform.parent = transform;
            yAxisVisual.transform.parent = transform;
            zAxisVisual.transform.parent = transform;

            // Set the length of the axis visuals
            xAxisVisual.transform.localScale = new Vector3(xAxisLength, axisSize, axisSize);
            yAxisVisual.transform.localScale = new Vector3(axisSize, yAxisLength, axisSize);
            zAxisVisual.transform.localScale = new Vector3(axisSize, axisSize, zAxisLength);

            // Set the position of the axis visuals
            xAxisVisual.transform.localPosition = new Vector3(xAxisLength / 2f, 0f, 0f);
            yAxisVisual.transform.localPosition = Vector3.zero;
            zAxisVisual.transform.localPosition = Vector3.zero;
            

            // Create a data point factory
            dataPointFactory = new DataPointFactory();

            GenerateRandomDataPoints();
        }


        // Add a data point to the graph
        public void AddDataPoint(float x, float y, float z, Color color)
        {
            DataPoint dataPoint = dataPointFactory.CreateDataPoint(x, y, z, transform.localScale, color);
            dataPoints.Add(dataPoint);
            dataPoint.Visual.transform.parent = transform;
            dataPoint.Visual.transform.localPosition = dataPoint.Position;
            dataPoint.Visual.GetComponent<Renderer>().material.color = dataPoint.Color;
        }

        // Remove all data points from the graph
        public void ClearDataPoints()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            dataPoints.Clear();
        }

        void GenerateRandomDataPoints()
        {
            for (int i = 0; i < 20; i++)
            {
                float x = Random.Range(0, xAxisLength);
                float y = Random.Range(-yAxisLength / 2f, yAxisLength / 2f);
                float z = Random.Range(-zAxisLength / 2f, zAxisLength / 2f);

                Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                AddDataPoint(x, y, z, color);

                //Debug.Log($"Created new data point at {x}, {y}, {z} with color {color}");
            }
        }

    }
}