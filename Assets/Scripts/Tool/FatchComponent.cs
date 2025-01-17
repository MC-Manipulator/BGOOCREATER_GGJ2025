using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// FetchComponent的静态方法会根据泛型T的类去获取gameObject上拥有的组件中，第一个对应是泛型T的子类的组件
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
