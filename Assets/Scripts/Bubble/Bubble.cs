using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Bubble
{
    float size { get; set; }//大小
    float speed { get; set; }//左右移动速度
    Vector2 position { get; set; }//二维坐标

    void UpdatePosition(float deltaTime);//更新位置
}
