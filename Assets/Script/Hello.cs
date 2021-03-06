﻿using UnityEngine;
using System.Collections.Generic;

// Transformation
// http://gad.qq.com/program/translateview/7181958

public class Hello : MonoBehaviour
{

    public Transform prefab;

    public int gridResolution = 10;

    Transform[] grid;

    List<Transformation> transformations;

    Matrix4x4 transformation = Matrix4x4.identity;

    void Awake()
    {
        grid = new Transform[gridResolution * gridResolution * gridResolution];
        for (int i = 0, z = 0; z < gridResolution; z++)
        {
            for (int y = 0; y < gridResolution; y++)
            {
                for (int x = 0; x < gridResolution; x++)
                {
                    grid[i++] = CreateGridPoint(x, y, z);
                }
            }
        }

        transformations = new List<Transformation>();
    }

    Transform CreateGridPoint(int x, int y, int z)
    {
        Transform point = Instantiate(prefab);
        point.localPosition = GetCoordinates(x, y, z);
        point.GetComponent<MeshRenderer>().material.color = new Color(
            (float)x / gridResolution,
            (float)y / gridResolution,
            (float)z / gridResolution
        );
        return point;
    }

    Vector3 GetCoordinates(int x, int y, int z)
    {
        return new Vector3(
            x - (gridResolution - 1) * 0.5f,
            y - (gridResolution - 1) * 0.5f,
            z - (gridResolution - 1) * 0.5f
        );
    }

    Vector3 TransformPoint(int x, int y, int z)
    {
        // 这里希望对初始坐标做变换
        Vector3 coordinates = GetCoordinates(x, y, z);
        for (int i = 0; i < transformations.Count; i++)
        {
            coordinates = transformations[i].Apply(coordinates);
        }
        return coordinates;
    }

    void UpdateTransformation()
    {
        GetComponents(transformations);
        if (transformations.Count > 0)
        {
            transformation = transformations[0].Matrix;
            for (int i = 1; i < transformations.Count; i++)
            {
                transformation = transformations[i].Matrix * transformation;
            }
        }
    }

    void onEnable()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 直接变换
        //GetComponents<Transformation>(transformations);
        //for (int i = 0, z = 0; z < gridResolution; z++)
        //{
        //    for (int y = 0; y < gridResolution; y++)
        //    {
        //        for (int x = 0; x < gridResolution; x++, i++)
        //        {
        //            grid[i].localPosition = TransformPoint(x, y, z);
        //        }
        //    }
        //}

        // 使用矩阵
        UpdateTransformation();
        for (int i = 0, z = 0; z < gridResolution; z++)
        {
            for (int y = 0; y < gridResolution; y++)
            {
                for (int x = 0; x < gridResolution; x++, i++)
                {
                    grid[i].localPosition = transformation.MultiplyPoint(GetCoordinates(x, y, z));
                }
            }
        }


    }

}