using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    private int newScore;
    public TextMeshProUGUI Score;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject TapToFlapText;
    public bool isTouch = false;
    void Start()
    {
        gameOver = false;
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Score.text == "0")
        {
            TapToFlapText.SetActive(false);
            isTouch = true;
        }
    }
    public void GameOver()
    {
        if (!gameOver)
        {
            gameOver = true;
            gameOverMenu.SetActive(true);
            if (newScore > DataManager.Instance.highScore)
            {
                DataManager.Instance.highScore = newScore;
                DataManager.Instance.SaveHighScore();
                DataManager.Instance.RefreshScoreTitle();
            }
        }
    }
    public void AddScore()
    {
        newScore++;
        Score.text = newScore.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}