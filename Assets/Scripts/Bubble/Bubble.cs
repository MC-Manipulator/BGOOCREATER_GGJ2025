using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Bubble
{
    float size { get; set; }//��С
    float speed { get; set; }//�����ƶ��ٶ�
    Vector2 position { get; set; }//��ά����

    void UpdatePosition(float deltaTime);//����λ��
}
