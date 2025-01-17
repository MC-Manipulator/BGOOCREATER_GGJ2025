using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// FetchComponent�ľ�̬��������ݷ���T����ȥ��ȡgameObject��ӵ�е�����У���һ����Ӧ�Ƿ���T����������
/// </summary>
public class FetchComponent
{
    public static Component Get<T>(GameObject gameObject)
    {
        Component[] componets = gameObject.GetComponents<Component>();
        foreach (Component cp in componets)
        {
            if (cp is T)
            {
                return cp;
            }
        }
        return null;
    }
}
