using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 小工具类
/// <para>描述</para>
/// </summary>
public static class Tool
{
    // 方法


    /// <summary>
    /// 顺时针旋转Vector2向量
    /// </summary>
    /// <param name="v">向量</param>
    /// <param name="radian">弧度</param>
    /// <returns>旋转后的向量</returns>
    public static Vector2 Rotate(this Vector2 v, float radian)
    {
        // 计算旋转矩阵的元素
        float cosTheta = Mathf.Cos(radian);
        float sinTheta = Mathf.Sin(radian);

        // 应用旋转矩阵
        float x = v.x * cosTheta - v.y * sinTheta;
        float y = v.x * sinTheta + v.y * cosTheta;

        return new Vector2(x, y);
    }
}

