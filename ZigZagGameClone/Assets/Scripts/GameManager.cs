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
        highScore.text = "HighScore :" + GetHighScore().ToString();    //�}�l�C���e��̰ܳ���
    }

    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<RoadBuild>().StartBuilding();    //�q�o�����RoadBuild�o�Ӹ}���}�l�B�@
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))    //�p�G���Uenter�C���N�|�}�l
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
        scoreText.text = score.ToString();    //����int�ন�r��
        if (score > GetHighScore())    //�p�G���Ƥj��̰���  ���N
        {
            PlayerPrefs.SetInt("Highscore",score);    //�]�w�̰�������e����
            highScore.text = "HighScore :" + score.ToString();    //�}�l�C�������
        }
    }

    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("Highscore");    //���highscore������
        return i;
    }
}
