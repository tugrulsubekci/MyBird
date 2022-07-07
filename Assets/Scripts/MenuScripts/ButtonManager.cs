using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
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
        highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        RefreshMusicButtonText(DataManager.Instance.isMusicOn);
        RefreshHighScoreTitle();
    }
    private void Update()
    {
        if(!DataManager.Instance.isMusicOn)
        {
            FindObjectOfType<AudioManager>().Stop("Background");
        }
    }
    public void StartButton1()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(StartWith());
    }
    IEnumerator StartWith()
    {
        yield return new WaitForSeconds(0.2f);
        StartWithPlayer(1);
    }

    public void StartButton2()
    {
        if(DataManager.Instance.highScore >= 10)
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
            RefreshMusicButtonText(DataManager.Instance.isMusicOn);
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Background");
            DataManager.Instance.isMusicOn = true;
            RefreshMusicButtonText(DataManager.Instance.isMusicOn);
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
    void RefreshMusicButtonText(bool isMusicOn)
    {
        if(isMusicOn)
        {
            musicButtonText.text = "Music: On";
        }
        else
        {
            musicButtonText.text = "Music: Off";
        }
        
    }
    void RefreshHighScoreTitle()
    {
        highScoreText.text = $"High Score | {DataManager.Instance.playerName} | {DataManager.Instance.highScore}";
    }
}
