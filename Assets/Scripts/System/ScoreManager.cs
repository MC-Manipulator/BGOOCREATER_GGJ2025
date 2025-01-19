using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score; //�÷�

    [SerializeField]
    private float _timeRatio = 3000; //ʱ��ĵ÷ֳ���
    [SerializeField]
    private float _sizeRatio = 2000; //���ݴ�С�ĵ÷ֳ���

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
    }

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

        size = LevelManager.instance.GetPlayerSize(); 
        size = (int)(size * _sizeRatio);

        return size;
    }
}
