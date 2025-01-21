using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField]
    private float _timeRatio = 1500;    // 时间的得分乘数
    [SerializeField]
    private float _sizeRatio = 4;       // 大小的得分乘数

    private void Awake()
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
    }

    public int GetTotalScore()
    {
        return (int)CalculateScore();
    }

    public float CalculateScore()
    {
        float score = GetTimeScore() * GetSizeScore();
        return score;
    }

    public float GetTimeScore()
    {
        float time = LevelManager.instance.time;
        time = Mathf.Pow(time, -1);     // y = x^(-1)
        time *= _timeRatio;

        return time;
    }

    public float GetSizeScore()
    {
        float size = LevelManager.instance.GetPlayerSize(); 
        size = Mathf.Sqrt(size);
        size *= _sizeRatio;

        return size;
    }
}
