using DefaultNameSpace;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;


public enum LevelState
{
    Start, //关卡正式开始前的状态
    Game, //游戏进行状态
    Restart,
    End //关卡结算状态
}


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public LevelState state;

    public GameObject player;
    public GameObject scoreBoard;

    public float time;
    public string timeString;
    public Transform startPoint;
    public Transform endPoint;

    public int levelScore;

    public GameObject maincamera;
    public GameObject restartMask;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        player.GetComponent<Bubble>().OnDie += OnPlayerDie;

        FirstEnterLevel();
    }

    public void FirstEnterLevel()
    {
        time = 0;
        state = LevelState.Start;

        player.GetComponent<Bubble>().Size = 4;
        player.transform.position = new Vector3(startPoint.position.x, startPoint.position.y, 0);
        player.GetComponent<PlayerCtrl>().RestrictMove();

        ShowLevel();
    }

    public void RestartLevel()
    {
        state = LevelState.Restart;
        time = 0;
        player.GetComponent<PlayerCtrl>().RestrictMove();

        HideScoreBoard();
        restartMask.SetActive(true);
        restartMask.GetComponent<Animator>().Play("StartRestart");
    }

    public void ResetPlayer()
    {
        maincamera.transform.position = new Vector3(startPoint.position.x, startPoint.position.y, -10);
        player.transform.position = new Vector3(startPoint.position.x, startPoint.position.y, 0);
        player.GetComponent<Bubble>().Size = 4;
        restartMask.GetComponent<Animator>().Play("EndRestart");
    }

    public void EndRestart()
    {
        state = LevelState.Game;
        restartMask.SetActive(false);
        player.GetComponent<PlayerCtrl>().DerestrictMove();
    }

    private void Update()
    {
        if (state == LevelState.Start)
        {
            if (!maincamera.GetComponent<CameraFollow>().showingLevel && !isCountDown)
            {
                StartCountDown();
            }
        }

        if (state == LevelState.Game)
        {
            time += Time.deltaTime;
            if (player.transform.position.y > endPoint.position.y)
            {
                EndLevel();
            }
        }
    }

    public void OnPlayerDie()
    {
        RestartLevel();
    }

    public int GetPlayerSize()
    {
        int size = 0;

        size = (int)player.GetComponent<Bubble>().Size;

        return size;
    }

    private void ShowLevel()
    {
        maincamera.GetComponent<CameraFollow>().StartShowLevel();
    }

    public void StartLevel()
    {
        state = LevelState.Game;

        player.GetComponent<PlayerCtrl>().DerestrictMove();
    }

    public void EndLevel()
    {
        state = LevelState.End;
        timeString = time.ToString("F2");
        player.GetComponent<PlayerCtrl>().RestrictMove();
        ShowScoreBoard();
    }

    private void ShowScoreBoard()
    {
        int score = ScoreManager.instance.GetScore();
        int timescore = ScoreManager.instance.GetTimeScore();
        int sizescore = ScoreManager.instance.GetSizeScore();
        int levelscore = ScoreManager.instance.GetLevelScore();

        scoreBoard.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        Transform scoreList = scoreBoard.transform.Find("ScoreList");

        scoreList.Find("LevelScorePart").transform.Find("LevelScore").gameObject.GetComponent<TMP_Text>().text = sizescore.ToString();
        scoreList.Find("TimePart").transform.Find("Time").gameObject.GetComponent<TMP_Text>().text = timeString;
        scoreList.Find("TimeScorePart").transform.Find("TimeScore").gameObject.GetComponent<TMP_Text>().text = timeString;
        scoreList.Find("SizeScorePart").transform.Find("SizeScore").gameObject.GetComponent<TMP_Text>().text = sizescore.ToString();

        scoreList.Find("Score").transform.Find("Score").gameObject.GetComponent<TMP_Text>().text = score.ToString();
        scoreBoard.SetActive(true);
    }

    private void HideScoreBoard()
    {
        scoreBoard.SetActive(false);
    }

    public GameObject countDownText;
    public int countDownTime = 10;
    public int currentCountDownTime = 10;
    public Vector2 popSize = new Vector2(6, 6);
    public bool isCountDown;

    public void StartCountDown()
    {
        isCountDown = true;
        StartCoroutine("CountDown");

    }

    public void Pause()
    {

    }

    public void Resume()
    {

    }

    public void BackToMenu()
    {
        SceneTranslateManager.instance.ToMenu();
    }

    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1f);


        countDownText.SetActive(true);
        countDownText.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        currentCountDownTime = countDownTime;


        while (currentCountDownTime > 0)
        {
            countDownText.transform.localScale = popSize;
            countDownText.GetComponent<TMP_Text>().text = "" + currentCountDownTime;
            float count = 1;
            while (count > 0)
            {
                count -= Time.deltaTime;
                Vector2 currentvec = countDownText.transform.localScale;
                countDownText.transform.localScale = currentvec - new Vector2(2f, 2f) * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            //yield return new WaitForSeconds(1);
            currentCountDownTime -= 1;
        }

        countDownText.transform.localScale = popSize * 2;
        countDownText.GetComponent<TMP_Text>().text = "Start!";
        yield return new WaitForSeconds(0.8f);
        countDownText.SetActive(false);

        StartLevel();
        isCountDown = false;
        maincamera.GetComponent<PlayerCamera>().enabled = true;
    }
}
