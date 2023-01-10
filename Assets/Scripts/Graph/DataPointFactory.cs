using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Graph3D
{
    public class DataPointFactory
    {
        public DataPoint CreateDataPoint(float x, float y, float z, Vector3 scale, Color color, GameObject visual = null)
        {
            return new DataPoint(x, y, z, scale, color, visual);
        }
    }

}
