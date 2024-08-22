using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public Text scoreText;
    public Text highScore;

    private void Awake()
    {
        highScore.text = "HighScore :" + GetHighScore().ToString();    //開始遊戲前顯示最高分
    }

    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<RoadBuild>().StartBuilding();    //從這邊來讓RoadBuild這個腳本開始運作
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))    //如果按下enter遊戲就會開始
        {
            StartGame();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();    //分數int轉成字串
        if (score > GetHighScore())    //如果分數大於最高分  取代
        {
            PlayerPrefs.SetInt("Highscore",score);    //設定最高分為當前分數
            highScore.text = "HighScore :" + score.ToString();    //開始遊戲後顯示
        }
    }

    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("Highscore");    //抓取highscore的分數
        return i;
    }
}
