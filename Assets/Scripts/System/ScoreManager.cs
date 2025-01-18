using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score; //得分

    private float _timeRatio = 3000; //时间的得分乘数
    private float _sizeRatio = 2000; //泡泡大小的得分乘数

    public int GetScore()
    {
        CalculateScore();
        return score;
    }

    public int CalculateScore()
    {
        score = 0;


        score += GetLevelScore();
        score += GetTimeScore();
        score += GetSizeScore();


        return score;
    }

    public int GetLevelScore()
    {
        int score = 0;


        return score;
    }

    public int GetTimeScore()
    {
        float time = 0;

        time = LevelManager.instance.time;
        time = (int)(time * _timeRatio);

        return (int)time;
    }

    public int GetSizeScore()
    {
        int size = 0;

        //size = ; 
        size = (int)(size * _sizeRatio);

        return size;
    }
}
