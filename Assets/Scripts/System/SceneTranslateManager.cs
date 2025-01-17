using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// SceneTranslate类提供的静态方法用于封装转换场景的操作
/// </summary>
public class SceneTranslateManager : MonoBehaviour
{
    public MMF_Player mmfp;

    //private readonly static string menuName = "Menu"; //菜单场景的名称
    //private readonly static string loadingName = "Loading"; //加载界面场景的名称
    //private readonly static string gameName = "Game"; // 游戏场景的名称

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
