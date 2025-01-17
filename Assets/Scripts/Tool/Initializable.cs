using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
///Initializable接口被用于任何可能需要进行初始化，并且对于初始化有先后顺序要求的对象。<br/>
///在脚本组件扩展了该接口后，需要将带有该组件的游戏物体放入列表，并将其传递到Init类的静态方法中。<br/>
///</summary>
public interface Initializable
{
    public abstract void Initialize();
}


public class Init
{
    public static void Run(List<Initializable> list)
    {
        foreach (Initializable i in list)
        {
            i.Initialize();
        }
    }
}