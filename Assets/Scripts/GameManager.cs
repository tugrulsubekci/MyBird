using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    private int newScore;
    public TextMeshProUGUI scoreTitle;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject TapToFlapText;
    public bool isTouch = false;
    void Start()
    {
        gameOver = false;
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 && scoreTitle.text == "0" ) //Touch and keyboard
        {
            TapToFlapText.SetActive(false);
            isTouch = true;
        }
    }
    public void GameOver()
    {
        if (!gameOver)
        {
            FindObjectOfType<AudioManager>().Play("GameOver");
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
        scoreTitle.text = newScore.ToString();
        FindObjectOfType<AudioManager>().Play("Score");
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