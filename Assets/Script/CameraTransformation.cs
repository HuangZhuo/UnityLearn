using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class CameraTransformation : Transformation
{
    public override Vector3 Apply(Vector3 point)
    {
        throw new NotImplementedException();
    }

    public override Matrix4x4 Matrix
    {
        get
        {
            var matrix = new Matrix4x4();
            matrix.SetRow(0, new Vector4(1, 0, 0, 0));
            matrix.SetRow(1, new Vector4(0, 1, 0, 0));
            matrix.SetRow(2, new Vector4(0, 0, 0, 0));
            matrix.SetRow(3, new Vector4(0, 0, 0, 1));
            return matrix;
        }
    }
}
