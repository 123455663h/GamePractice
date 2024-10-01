using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("���Ƥ���")]
    public int score;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;

    [Header("�C������")]    //��ܦbUnity
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
        highScore = PlayerPrefs.GetInt("HighScore");    //�]�wKey�Ψ��x�s
        highScoreText.text = "Best : " + highScore;
    }

    public void IncreaseScore(int points)    //�令�o�˴N���ΨC�����ӳo���ƭ�
    {
        score += points;
        scoreText.text = score.ToString();
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore",score);    //��Highscore��Key�����ȳ]�w��score���ƭ�
            highScoreText.text = "Best : " + score.ToString();
        }
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;    //����0�N�O�Ȱ��C��
        gameOverScoreText.text = "Score : " + score.ToString();
        highScore = PlayerPrefs.GetInt("HighScore");    //���C�������ɪ��̰������ܼƭ�
        gameOverHighScoreText.text = "Best : " + highScore.ToString();
        gameOverPanel.SetActive(true);
    }

    public void Restart()    //���s�}�l�C��
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOverPanel.SetActive(false);

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))    //�R���Ҧ���""��Tag����
        {
            Destroy(g);
        }

        Time.timeScale = 1;
    }
}
