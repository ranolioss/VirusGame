using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemaneger : MonoBehaviour
{ public static Gamemaneger Instance { private set;get;}
    public int HighScore { private set; get; } private const string HighScoreKEY = "HighScore";
    public int score { private set; get; }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {

        HighScore = PlayerPrefs.GetInt(HighScoreKEY);// show high score//
        UlManeger.Instance.setHighScore(HighScore);
        score = 0;// before start show score 0//
    }
    public void addscore()
    {
        score++;// if player move the obstacel add in score//
        UlManeger.Instance.setscore(score);
        if (HighScore < score)// if highescore < score show the high score//
        {

            HighScore = score;
            UlManeger.Instance.setHighScore(HighScore);
            PlayerPrefs.SetInt(HighScoreKEY, HighScore);
            PlayerPrefs.Save();
        }

    }
}
