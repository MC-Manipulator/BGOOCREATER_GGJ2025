using DefaultNameSpace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum LevelState
{
    Start, //关卡正式开始前的状态
    Game, //游戏进行状态
    Pause, //暂停状态
    Restart, //重新开始游戏
    End //关卡结算状态
}


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public LevelState state;

    public GameObject player;
    public GameObject scoreBoard;
    public GameObject pauseBoard;
    public GameObject timeRecord;
    public GameObject instructionBar;

    public float time;
    public string timeString;
    public Transform startPoint;
    public Transform endPoint;

    public int levelScore;

    public GameObject maincamera;
    public GameObject restartMask;
    public GameObject bubblePool;
    public int levelNo = 0;

    private void Awake()
    {
        instance = this;

        player.GetComponent<Bubble>().OnDie += OnPlayerDie;

        FirstEnterLevel();
    }

    private void Start()
    {
        if (GameManager.instance)
        {
            GameManager.instance.state = GameState.Game;
            GameManager.instance.RefreshLevelLanguage();
        }
    }

    public void CleanPool()
    {
        int size = bubblePool.transform.childCount;
        for (int i = 0;i < size;i++)
        {
            Destroy(bubblePool.transform.GetChild(i).gameObject);
        }
    }

    public void FirstEnterLevel()
    {
        time = 0;
        state = LevelState.Start;
        instructionBar.SetActive(true);
        //Pause();
        player.SetActive(true);
        player.GetComponent<Bubble>().Size = 4;
        player.transform.position = new Vector3(startPoint.position.x, startPoint.position.y, 0);
        player.GetComponent<PlayerCtrl>().RestrictMove();

        ShowLevel();
    }

    public void RestartLevel()
    {
        Resume();
        state = LevelState.Restart;
        time = 0;
        player.GetComponent<PlayerCtrl>().RestrictMove();

        HideScoreBoard();
        restartMask.SetActive(true);
        restartMask.GetComponent<Animator>().Play("StartRestart");
    }

    public void ResetPlayer()
    {
        CleanPool();
        player.SetActive(true);
        maincamera.transform.position = new Vector3(startPoint.position.x, startPoint.position.y, -10);
        player.transform.position = new Vector3(startPoint.position.x, startPoint.position.y, 0);
        player.GetComponent<Bubble>().Size = 4;
        player.GetComponent<Bubble>().isDead = false;
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
                maincamera.GetComponent<CameraFollow>().enabled = false;
                StartCountDown();
            }
        }

        if (state == LevelState.Game)
        {
            time += Time.deltaTime;
            GameObject.Find("TimeValue").GetComponent<TMP_Text>().text = time.ToString("F2");
            if (player.transform.position.y > endPoint.position.y)
            {
                EndLevel();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (state == LevelState.Pause)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void OnPlayerDie()
    {
        player.SetActive(false);
        RestartLevel();
    }

    public int GetPlayerSize()
    {
        int size = (int)player.GetComponent<Bubble>().Size;
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

        scoreList.Find("TimePart").transform.Find("Time").gameObject.GetComponent<TMP_Text>().text = timeString;
        scoreList.Find("TimeScorePart").transform.Find("TimeScore").gameObject.GetComponent<TMP_Text>().text = timescore.ToString();
        scoreList.Find("SizeScorePart").transform.Find("SizeScore").gameObject.GetComponent<TMP_Text>().text = sizescore.ToString();
        scoreList.Find("LevelScorePart").transform.Find("LevelScore").gameObject.GetComponent<TMP_Text>().text = levelScore.ToString();

        scoreList.Find("Score").transform.Find("Score").gameObject.GetComponent<TMP_Text>().text = score.ToString();
        scoreBoard.SetActive(true);

        ES3.Save("Level" + levelNo, score);
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
        StartCoroutine(nameof(CountDown));

    }

    public void Pause()
    {
        Time.timeScale = 0f;
        state = LevelState.Pause;
        pauseBoard.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        state = LevelState.Game;
        pauseBoard.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneTranslateManager.instance.ToMenu();
    }

    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1f);
        instructionBar.SetActive(false);

        // 开始缩放
        maincamera.GetComponent<PlayerCamera>().enabled = true;

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
        timeRecord.SetActive(true);

        StartLevel();
        isCountDown = false;
    }
}
