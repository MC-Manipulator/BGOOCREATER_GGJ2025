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

        for (int i = 1;i < 3;i++)
        {
            scoreList[i] = ES3.Load<int>("Level" + i, 0);
        }
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
            GameObject.Find("StartButton").GetComponentInChildren<TMP_Text>().text = "��ʼ��Ϸ";
            GameObject.Find("ExitButton").GetComponentInChildren<TMP_Text>().text = "�˳���Ϸ";
            GameObject.Find("Canvas").transform.Find("BackButton").Find("Text").GetComponent<TMP_Text>().text = "����";
            GameObject.Find("Canvas").transform.Find("BackToChapterSelectButton").Find("Text").GetComponent<TMP_Text>().text = "����";
        }
        if (language == Language.English)
        {
            GameObject.Find("StartButton").GetComponentInChildren<TMP_Text>().text = "Start";
            GameObject.Find("ExitButton").GetComponentInChildren<TMP_Text>().text = "Exit";
            GameObject.Find("Canvas").transform.Find("BackButton").Find("Text").GetComponent<TMP_Text>().text = "Back";
            GameObject.Find("Canvas").transform.Find("BackToChapterSelectButton").Find("Text").GetComponent<TMP_Text>().text = "Back";
        }
    }

    public void RefreshLevelLanguage()
    {
        if (language == Language.Chinese)
        {
            Transform scorebar = GameObject.Find("Canvas").transform.Find("ScoreBar");
            scorebar.transform.Find("Title").Find("TitleText").GetComponent<TMP_Text>().text = "��Ϸ����";

            Transform scoreList = scorebar.Find("ScoreList");
            scoreList.Find("TimePart").Find("TimeText").GetComponent<TMP_Text>().text = "ʱ��:";
            scoreList.Find("TimeScorePart").Find("TimeScoreText").GetComponent<TMP_Text>().text = "ʱ��÷�:";
            scoreList.Find("SizeScorePart").Find("SizeText").GetComponent<TMP_Text>().text = "��С�÷�:";
            scoreList.Find("LevelScorePart").Find("LevelScoreText").GetComponent<TMP_Text>().text = "�ؿ��÷�:";
            scoreList.Find("Score").Find("Text").GetComponent<TMP_Text>().text = "�ܷ�:";

            scorebar.transform.Find("BackButton").Find("Text").GetComponent<TMP_Text>().text = "���ز˵�";
            scorebar.transform.Find("RestartButton").Find("Text").GetComponent<TMP_Text>().text = "���¿�ʼ";


            Transform pauseBar = GameObject.Find("Canvas").transform.Find("PauseBar");
            pauseBar.Find("Title").Find("TitleText").GetComponent<TMP_Text>().text = "��ͣ";
            pauseBar.Find("ResumeButton").Find("Text").GetComponent<TMP_Text>().text = "������Ϸ";
            pauseBar.Find("RestartButton").Find("Text").GetComponent<TMP_Text>().text = "���¿�ʼ";
            pauseBar.Find("BackButton").Find("Text").GetComponent<TMP_Text>().text = "���ز˵�";

            Transform timeRecord = GameObject.Find("Canvas").transform.Find("TimeRecord");
            timeRecord.Find("Text").GetComponent<TMP_Text>().text = "ʱ��:";
        }
        if (language == Language.English)
        {
            Transform scorebar = GameObject.Find("Canvas").transform.Find("ScoreBar");
            scorebar.transform.Find("Title").Find("TitleText").GetComponent<TMP_Text>().text = "Game End";

            Transform scoreList = scorebar.Find("ScoreList");
            scoreList.Find("TimePart").Find("TimeText").GetComponent<TMP_Text>().text = "Time:";
            scoreList.Find("TimeScorePart").Find("TimeScoreText").GetComponent<TMP_Text>().text = "Time Score:";
            scoreList.Find("SizeScorePart").Find("SizeText").GetComponent<TMP_Text>().text = "Size Score:";
            scoreList.Find("LevelScorePart").Find("LevelScoreText").GetComponent<TMP_Text>().text = "Level Score:";
            scoreList.Find("Score").Find("Text").GetComponent<TMP_Text>().text = "Totel Score:";

            scorebar.transform.Find("BackButton").Find("Text").GetComponent<TMP_Text>().text = "Back To Menu";
            scorebar.transform.Find("RestartButton").Find("Text").GetComponent<TMP_Text>().text = "Restart";


            Transform pauseBar = GameObject.Find("Canvas").transform.Find("PauseBar");
            pauseBar.Find("Title").Find("TitleText").GetComponent<TMP_Text>().text = "Pause";
            pauseBar.Find("ResumeButton").Find("Text").GetComponent<TMP_Text>().text = "Resume";
            pauseBar.Find("RestartButton").Find("Text").GetComponent<TMP_Text>().text = "Restart";
            pauseBar.Find("BackButton").Find("Text").GetComponent<TMP_Text>().text = "Back To Menu";

            Transform timeRecord = GameObject.Find("Canvas").transform.Find("TimeRecord");
            timeRecord.Find("Text").GetComponent<TMP_Text>().text = "Time:";
        }
    }
}
