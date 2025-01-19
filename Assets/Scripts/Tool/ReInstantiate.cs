using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ReInstantiate类提供的静态方法可以在对GameObject进行初始化时，去掉其后附带的(Clone)
/// </summary>
public class ReInstantiate
{
    public static GameObject Run(GameObject prefab)
    {
        GameObject gb = null;
        ///
        gb = GameObject.Instantiate(prefab, new Vector2(0, 0), new Quaternion(0, 0, 0, 0));
        gb.name = gb.name.Replace("(Clone)", "");

        return gb;
    }

    public static GameObject Run(GameObject prefab, Transform parent)
    {
        GameObject gb = null;
        ///
        gb = GameObject.Instantiate(prefab, new Vector2(0, 0), new Quaternion(0, 0, 0, 0));
        gb.name = gb.name.Replace("(Clone)", "");
        gb.transform.SetParent(parent);

        return gb;
    }

    public static GameObject Run(GameObject prefab, Vector2 position)
    {
        GameObject gb = null;

        gb = GameObject.Instantiate(prefab, position, new Quaternion(0, 0, 0, 0));
        gb.name = gb.name.Replace("(Clone)", "");

        return gb;
    }

    public static GameObject Run(GameObject prefab, Vector2 position, Transform parent)
    {
        GameObject gb = null;

        gb = GameObject.Instantiate(prefab, position, new Quaternion(0, 0, 0, 0));
        gb.name = gb.name.Replace("(Clone)", "");
        gb.transform.SetParent(parent);

        return gb;
    }

    public static GameObject Run(GameObject prefab, Vector2 position, Quaternion quaternion)
    {
        GameObject gb = null;

        gb = GameObject.Instantiate(prefab, position, quaternion);
        gb.name = gb.name.Replace("(Clone)", "");

        return gb;
    }

    public static GameObject Run(GameObject prefab, Vector2 position, Quaternion quaternion, Transform parent)
    {
        GameObject gb = null;

        gb = GameObject.Instantiate(prefab, position, quaternion);
        gb.name = gb.name.Replace("(Clone)", "");
        gb.transform.SetParent(parent);

        return gb;
    }
}
