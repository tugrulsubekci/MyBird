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
    public GameObject warning;
    public void StartButton1()
    {
        StartWithPlayer(1);
    }

    public void StartButton2()
    {
        StartWithPlayer(2);
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }

    void StartWithPlayer(int playerIndex) // ABSTRACTION
    {
        if (inputName.text.Length > 1)
        {
            DataManager.Instance.playerIndex = playerIndex;
            SceneManager.LoadScene(1);
            DataManager.Instance.playerName = inputName.text;
        }
        else
        {
            warning.SetActive(true);
        }
    }
}