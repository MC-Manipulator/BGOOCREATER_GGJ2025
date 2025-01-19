using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum Language
{
    English,
    Chinese
}

public enum GameState
{
    Menu,
    Game
}


public class GameManager : MonoBehaviour
{
    public GameState state;
    public static GameManager instance;
    public Language language;

    public Dictionary<int, int> scoreList = new Dictionary<int, int>();

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    public void LoadData()
    {
        language = ES3.Load<Language>("Language", Language.Chinese);

        for (int i = 1;i <= 3;i++)
        {
            scoreList[i] = ES3.Load<int>("Level" + i, 0);
        }

        GameObject.Find("Canvas").transform.Find("LevelSelect").Find("Level1").Find("Level1Score").GetComponent<TMP_Text>().text = scoreList[1].ToString();
        GameObject.Find("Canvas").transform.Find("LevelSelect").Find("Level2").Find("Level2Score").GetComponent<TMP_Text>().text = scoreList[2].ToString();
        GameObject.Find("Canvas").transform.Find("LevelSelect").Find("Level3").Find("Level3Score").GetComponent<TMP_Text>().text = scoreList[3].ToString();
    }

    public void SetChinese()
    {
        language = Language.Chinese;
        ES3.Save("Language", language);
        RefreshMenuLanguage();
    }

    public void SetEngish()
    {
        language = Language.English;
        ES3.Save("Language", language);
        RefreshMenuLanguage();
    }

    public void RefreshMenuLanguage()
    {
        if (language == Language.Chinese)
        {
            GameObject.Find("StartButton").GetComponentInChildren<TMP_Text>().text = "开始游戏";
            GameObject.Find("ExitButton").GetComponentInChildren<TMP_Text>().text = "退出游戏";
            GameObject.Find("StaffButton").GetComponentInChildren<TMP_Text>().text = "开发人员";
            GameObject.Find("Canvas").transform.Find("BackButton").Find("Text").GetComponent<TMP_Text>().text = "返回";
            GameObject.Find("Canvas").transform.Find("BackToChapterSelectButton").Find("Text").GetComponent<TMP_Text>().text = "返回";
            GameObject.Find("Canvas").transform.Find("LevelSelect").Find("Level1").Find("Level1ScoreText").GetComponent<TMP_Text>().text = "得分:";
            GameObject.Find("Canvas").transform.Find("LevelSelect").Find("Level2").Find("Level2ScoreText").GetComponent<TMP_Text>().text = "得分:";
            GameObject.Find("Canvas").transform.Find("LevelSelect").Find("Level3").Find("Level3ScoreText").GetComponent<TMP_Text>().text = "得分:";
        }
        if (language == Language.English)
        {
            GameObject.Find("StartButton").GetComponentInChildren<TMP_Text>().text = "Start";
            GameObject.Find("ExitButton").GetComponentInChildren<TMP_Text>().text = "Exit";
            GameObject.Find("StaffButton").GetComponentInChildren<TMP_Text>().text = "Staff";
            GameObject.Find("Canvas").transform.Find("BackButton").Find("Text").GetComponent<TMP_Text>().text = "Back";
            GameObject.Find("Canvas").transform.Find("BackToChapterSelectButton").Find("Text").GetComponent<TMP_Text>().text = "Back";
            GameObject.Find("Canvas").transform.Find("LevelSelect").Find("Level1").Find("Level1ScoreText").GetComponent<TMP_Text>().text = "Score:";
            GameObject.Find("Canvas").transform.Find("LevelSelect").Find("Level2").Find("Level2ScoreText").GetComponent<TMP_Text>().text = "Score:";
            GameObject.Find("Canvas").transform.Find("LevelSelect").Find("Level3").Find("Level3ScoreText").GetComponent<TMP_Text>().text = "Score:";
        }
    }

    public void RefreshLevelLanguage()
    {
        if (language == Language.Chinese)
        {
            Transform scorebar = GameObject.Find("GameCanvas").transform.Find("ScoreBar");
            scorebar.transform.Find("Title").Find("TitleText").GetComponent<TMP_Text>().text = "游戏结束";

            Transform scoreList = scorebar.Find("ScoreList");
            scoreList.Find("TimePart").Find("TimeText").GetComponent<TMP_Text>().text = "时间:";
            scoreList.Find("TimeScorePart").Find("TimeScoreText").GetComponent<TMP_Text>().text = "时间得分:";
            scoreList.Find("SizeScorePart").Find("SizeText").GetComponent<TMP_Text>().text = "大小得分:";
            scoreList.Find("LevelScorePart").Find("LevelScoreText").GetComponent<TMP_Text>().text = "关卡得分:";
            scoreList.Find("Score").Find("Text").GetComponent<TMP_Text>().text = "总分:";

            scorebar.transform.Find("BackButton").Find("Text").GetComponent<TMP_Text>().text = "返回菜单";
            scorebar.transform.Find("RestartButton").Find("Text").GetComponent<TMP_Text>().text = "重新开始";


            Transform pauseBar = GameObject.Find("GameCanvas").transform.Find("PauseBar");
            pauseBar.Find("Title").Find("TitleText").GetComponent<TMP_Text>().text = "暂停";
            pauseBar.Find("ResumeButton").Find("Text").GetComponent<TMP_Text>().text = "返回游戏";
            pauseBar.Find("RestartButton").Find("Text").GetComponent<TMP_Text>().text = "重新开始";
            pauseBar.Find("BackButton").Find("Text").GetComponent<TMP_Text>().text = "返回菜单";

            Transform timeRecord = GameObject.Find("GameCanvas").transform.Find("TimeRecord");
            timeRecord.Find("Text").GetComponent<TMP_Text>().text = "时间:";
        }
        if (language == Language.English)
        {
            Transform scorebar = GameObject.Find("GameCanvas").transform.Find("ScoreBar");
            scorebar.transform.Find("Title").Find("TitleText").GetComponent<TMP_Text>().text = "Game End";

            Transform scoreList = scorebar.Find("ScoreList");
            scoreList.Find("TimePart").Find("TimeText").GetComponent<TMP_Text>().text = "Time:";
            scoreList.Find("TimeScorePart").Find("TimeScoreText").GetComponent<TMP_Text>().text = "Time Score:";
            scoreList.Find("SizeScorePart").Find("SizeText").GetComponent<TMP_Text>().text = "Size Score:";
            scoreList.Find("LevelScorePart").Find("LevelScoreText").GetComponent<TMP_Text>().text = "Level Score:";
            scoreList.Find("Score").Find("Text").GetComponent<TMP_Text>().text = "Totel Score:";

            scorebar.transform.Find("BackButton").Find("Text").GetComponent<TMP_Text>().text = "Back To Menu";
            scorebar.transform.Find("RestartButton").Find("Text").GetComponent<TMP_Text>().text = "Restart";


            Transform pauseBar = GameObject.Find("GameCanvas").transform.Find("PauseBar");
            pauseBar.Find("Title").Find("TitleText").GetComponent<TMP_Text>().text = "Pause";
            pauseBar.Find("ResumeButton").Find("Text").GetComponent<TMP_Text>().text = "Resume";
            pauseBar.Find("RestartButton").Find("Text").GetComponent<TMP_Text>().text = "Restart";
            pauseBar.Find("BackButton").Find("Text").GetComponent<TMP_Text>().text = "Back To Menu";

            Transform timeRecord = GameObject.Find("GameCanvas").transform.Find("TimeRecord");
            timeRecord.Find("Text").GetComponent<TMP_Text>().text = "Time:";
        }
    }
}
