using UnityEngine;
using TMPro;

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
            }
        }
    }
    public void AddScore()
    {
        newScore++;
        scoreTitle.text = newScore.ToString();
        FindObjectOfType<AudioManager>().Play("Score");
    }
}