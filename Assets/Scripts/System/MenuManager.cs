using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public GameObject menuObject;
    public Animator menuAnimator;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        menuAnimator = menuObject.GetComponent<Animator>();
    }

    public void EnterChapterSelect()
    {
        menuAnimator.Play("EnterChapterSelect");
    }

    public void ExitChapterSelect()
    {
        menuAnimator.Play("ExitChapterSelect");
    }

    public void StartGame()
    {

    }

    public void ExitGame()
    {

    }
}
