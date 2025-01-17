using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// SceneTranslate���ṩ�ľ�̬�������ڷ�װת�������Ĳ���
/// </summary>
public class SceneTranslateManager : MonoBehaviour
{
    public MMF_Player mmfp;

    //private readonly static string menuName = "Menu"; //�˵�����������
    //private readonly static string loadingName = "Loading"; //���ؽ��泡��������
    //private readonly static string gameName = "Game"; // ��Ϸ����������

    public static SceneTranslateManager instance;

    private void Awake()
    {
        if (SceneTranslateManager.instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToMenu()
    {
        //SceneManager.LoadScene(menuName);
    }

    public void ToGame()
    {
        mmfp.PlayFeedbacks();
        //SceneManager.LoadScene(gameName);
    }
}
