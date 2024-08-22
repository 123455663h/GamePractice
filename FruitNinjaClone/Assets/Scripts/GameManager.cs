using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("分數元素")]
    public int score;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;

    [Header("遊戲結束")]    //顯示在Unity
    public GameObject gameOverPanel;
    public Text gameOverScoreText;
    public Text gameOverHighScoreText;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        GetHighScore();
    }

    private void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");    //設定Key用來儲存
        highScoreText.text = "Best : " + highScore;
    }

    public void IncreaseScore(int points)    //改成這樣就不用每次都來這邊改數值
    {
        score += points;
        scoreText.text = score.ToString();
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore",score);    //把Highscore的Key對應值設定成score的數值
            highScoreText.text = "Best : " + score.ToString();
        }
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;    //等於0就是暫停遊戲
        gameOverScoreText.text = "Score : " + score.ToString();
        highScore = PlayerPrefs.GetInt("HighScore");    //讓遊戲結束時的最高分改變數值
        gameOverHighScoreText.text = "Best : " + highScore.ToString();
        gameOverPanel.SetActive(true);
    }

    public void Restart()    //重新開始遊戲
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOverPanel.SetActive(false);

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))    //刪除所有有""的Tag物件
        {
            Destroy(g);
        }

        Time.timeScale = 1;
    }
}
