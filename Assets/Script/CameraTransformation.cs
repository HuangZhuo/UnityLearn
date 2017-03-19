using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class CameraTransformation : Transformation
{
    // 焦距
    public float focalLength;

    public override Vector3 Apply(Vector3 point)
    {
        throw new NotImplementedException();
    }

    public override Matrix4x4 Matrix
    {
        // 平行投影到XY平面
        //get
        //{
        //    var matrix = new Matrix4x4();
        //    matrix.SetRow(0, new Vector4(1, 0, 0, 0));
        //    matrix.SetRow(1, new Vector4(0, 1, 0, 0));
        //    matrix.SetRow(2, new Vector4(0, 0, 0, 0));
        //    matrix.SetRow(3, new Vector4(0, 0, 0, 1));
        //    return matrix;
        //}

        // 透视投影
        get
        {
            var matrix = new Matrix4x4();
            matrix.SetRow(0, new Vector4(focalLength, 0, 0, 0));
            matrix.SetRow(1, new Vector4(0, focalLength, 0, 0));
            matrix.SetRow(2, new Vector4(0, 0, 0, 0));
            matrix.SetRow(3, new Vector4(0, 0, 1, 0));
            return matrix;
        }
    }
}
