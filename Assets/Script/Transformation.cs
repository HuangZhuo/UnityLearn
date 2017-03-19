using UnityEngine;
using System.Collections;

// 变换基类
public abstract class Transformation : MonoBehaviour {

    // 第一版：直接做变换
    public abstract Vector3 Apply(Vector3 point);

    // 使用变换矩阵
    public abstract Matrix4x4 Matrix { get; }

}
