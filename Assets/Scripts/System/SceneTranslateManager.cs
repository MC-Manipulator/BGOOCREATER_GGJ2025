using MoreMountains.Feedbacks;
using MoreMountains.Tools;
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

    private readonly static string menuName = "Menu"; //菜单场景的名称
    //private readonly static string loadingName = "Loading"; //加载界面场景的名称
    private readonly static string gameName = "Level"; // 游戏场景的名称

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
