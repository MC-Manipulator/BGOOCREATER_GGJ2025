using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
///Initializable�ӿڱ������κο�����Ҫ���г�ʼ�������Ҷ��ڳ�ʼ�����Ⱥ�˳��Ҫ��Ķ���<br/>
///�ڽű������չ�˸ýӿں���Ҫ�����и��������Ϸ��������б������䴫�ݵ�Init��ľ�̬�����С�<br/>
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