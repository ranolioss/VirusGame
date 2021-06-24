using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UlManeger : MonoBehaviour
{
    public static UlManeger Instance { private set; get; }//you can use instance in other class//
    [SerializeField] GameObject MEnupanel;
    [SerializeField] GameObject gameoverpanel;

    [SerializeField] GameObject gameplaypanel;
    [SerializeField] Text scoretext;
    [SerializeField] Text HighScoretext;

    private void Awake()
    {
        Instance = this;
    }
    public void PlayGame()
    {
        MEnupanel.SetActive(false);// when player play start remove menu//
        gameplaypanel.SetActive(true);// when player start gaem show the score//
        setscore(0);
    }
    public void setHighScore(int score)
    {
        HighScoretext.text = "HighScore:" + score;
        
    }
    public void setscore(int score)
    {
        scoretext.text = "Score:" + score;
    }
    public void GameOver()
    {
        gameoverpanel.SetActive(true);  //when the player losse show the game over//
    }
}
