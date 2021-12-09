using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
    public static GameManagers instance;
    private static string HIGH_SCORE = "High Score";

    void Awake()
    {
        _MakeSingleInstance();
        IsGameStartedForTheFirstTime();
    }
    void _MakeSingleInstance()
    {
        if(instance !=null)
        {
            Destroy(gameObject);
        }else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);// khong huy
        }
    }
    void IsGameStartedForTheFirstTime()
    {
        if (PlayerPrefs.HasKey("IsGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE,0);
            PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
        }

    }
    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
}
