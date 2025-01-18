using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum LevelState
{
    Start, //关卡正式开始前的状态
    Game, //游戏进行状态
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
    public Vector2 startPoint;
    public Vector2 endPoint;

    public int levelScore;

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

        time = 0;
        state = LevelState.Start;
    }

    private void Update()
    {
        if (state == LevelState.Game)
            time += Time.deltaTime;
    }

    private void ShowLevel()
    {

    }

    public void StartLevel()
    {
        state = LevelState.Start;
    }

    public void EndLevel()
    {
        state = LevelState.End;
        timeString = time.ToString("F2");
        ShowScoreBoard();
    }

    private void ShowScoreBoard()
    {
        int score = ScoreManager.instance.GetScore();
        int timescore = ScoreManager.instance.GetTimeScore();
        int sizescore = ScoreManager.instance.GetSizeScore();
        int levelscore = ScoreManager.instance.GetLevelScore();

        scoreBoard.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        scoreBoard.transform.Find("Time").gameObject.GetComponent<TMP_Text>().text = timeString;
        scoreBoard.transform.Find("TimeScore").gameObject.GetComponent<TMP_Text>().text = timeString;
        scoreBoard.transform.Find("SizeScore").gameObject.GetComponent<TMP_Text>().text = sizescore.ToString();
        scoreBoard.transform.Find("Score").gameObject.GetComponent<TMP_Text>().text = score.ToString();
        scoreBoard.SetActive(true);
    }

    public GameObject countDownText;
    public int countDownTime = 10;
    public int currentCountDownTime = 10;
    public Vector2 popSize = new Vector2(6, 6);

    public void StartCountDown()
    {
        StartCoroutine("CountDown");

    }

    public IEnumerator CountDown()
    {
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
    }
}
