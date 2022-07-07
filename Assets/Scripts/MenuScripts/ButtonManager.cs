using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ButtonManager : MonoBehaviour
{
    public TextMeshProUGUI inputName;
    public GameObject nickNameWarning;
    public GameObject playerTwoWarning; 

    public TextMeshProUGUI musicButtonText;
    private TextMeshProUGUI highScoreText;
    private void Awake()
    {
        if(DataManager.Instance.isMusicOn)
        {
            musicButtonText.text = "Music: On";
        }
        else
        {
            musicButtonText.text = "Music: Off";
        }
        highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        highScoreText.text = $"High Score | {DataManager.Instance.playerName} | {DataManager.Instance.highScore}";
    }
    public void StartButton1()
    {
        StartWithPlayer(1);
    }

    public void StartButton2()
    {
        if(DataManager.Instance.highScore >=20)
        {
            StartWithPlayer(2);
        }
        else
        {
            playerTwoWarning.SetActive(true);
        }
        
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }
    public void MusicButton()
    {
        if(DataManager.Instance.isMusicOn)
        {
            DataManager.Instance.isMusicOn = false;
            musicButtonText.text = "Music: Off";
        }
        else
        {
            DataManager.Instance.isMusicOn = true;
            musicButtonText.text = "Music: On";
        }
    }

    void StartWithPlayer(int playerIndex) // ABSTRACTION
    {
        if (inputName.text.Length > 1) // In unity remote, you have to turn it to the true
        {
            DataManager.Instance.playerIndex = playerIndex;
            SceneManager.LoadScene(1);
            DataManager.Instance.playerName = inputName.text;
        }
        else
        {
            nickNameWarning.SetActive(true);
        }
    }
}
