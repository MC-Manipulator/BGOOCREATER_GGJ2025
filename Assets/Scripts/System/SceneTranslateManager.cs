using MoreMountains.Feedbacks;
using MoreMountains.Tools;
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

    private readonly static string menuName = "Menu"; //�˵�����������
    //private readonly static string loadingName = "Loading"; //���ؽ��泡��������
    private readonly static string gameName = "Level"; // ��Ϸ����������

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
        mmfp.GetFeedbackOfType<MMF_LoadScene>().DestinationSceneName = menuName;
        mmfp.PlayFeedbacks();
    }

    public void ToGame(int chapternumber, int levelnumber)
    {
        mmfp.GetFeedbackOfType<MMF_LoadScene>().DestinationSceneName = gameName + chapternumber + "-" + levelnumber;
        mmfp.PlayFeedbacks();
        //SceneManager.LoadScene("Level" + chapternumber + "-" + levelnumber);
    }
}
