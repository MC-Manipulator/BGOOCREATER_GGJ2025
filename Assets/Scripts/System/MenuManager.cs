using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public GameObject menuObject;
    public GameObject staffBar;
    public Animator menuAnimator;
    
    public GameObject clip;
    public int chapterNumber;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        menuAnimator = menuObject.GetComponent<Animator>();
        clip.GetComponent<AudioSource>().Play();
    }

    public void Start()
    {

        if (GameManager.instance)
        {
            GameManager.instance.state = GameState.Menu;
            GameManager.instance.RefreshMenuLanguage();
            GameManager.instance.LoadData();
        }
    }

    public void EnterChapterSelect()
    {
        menuAnimator.Play("EnterChapterSelect");
    }

    public void ExitChapterSelect()
    {
        menuAnimator.Play("ExitChapterSelect");
    }

    public void EnterChapter1LevelSelect()
    {
        menuAnimator.Play("EnterChapter1LevelSelect");
    }

    public void ExitChapter1LevelSelect()
    {
        menuAnimator.Play("ExitChapter1LevelSelect");
    }

    public void SetChapter(int chapternumber)
    {
        chapterNumber = chapternumber;
    }

    public void StartGame(int levelnumber)
    {
        clip.GetComponent<AudioSource>().Stop();
        SceneTranslateManager.instance.ToGame(chapterNumber, levelnumber);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenStaffBar()
    {
        staffBar.SetActive(true);
    }

    public void CloseStaffBar()
    {
        staffBar.SetActive(false);
    }

    public void SetChinese()
    {
        GameManager.instance.SetChinese();
    }

    public void SetEnglish()
    {
        GameManager.instance.SetEngish();
    }
}
