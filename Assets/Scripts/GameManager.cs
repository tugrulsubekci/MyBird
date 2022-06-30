using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    private int newScore;
    void Start()
    {
        gameOver = false;
    }

    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over");
    }
    public void AddScore()
    {
        newScore++;
        Debug.Log("Score: " + newScore);
    }
}
