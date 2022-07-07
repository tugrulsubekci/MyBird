using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverMenuManager : MonoBehaviour
{
    private float waitTime = 0.2f;
    public void RestartButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(LoadSce(1));
    }
    public void BackToMenuButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(LoadSce(0));
    }
    IEnumerator LoadSce(int indexOfScene)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(indexOfScene);
    }
}