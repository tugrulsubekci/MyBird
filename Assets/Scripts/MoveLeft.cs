using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed; //ENCAPSULATION

    private GameManager gameManager;
    private bool isMethodUsed = false;
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void FixedUpdate()
    {
        if(!gameManager.gameOver)
        {
            Move();
        }
        
    }
    private void LateUpdate()
    {
        if (isPlayerPassed() && !isMethodUsed)
        {
            gameManager.AddScore();
            isMethodUsed = true;
        }
    }

    void Move() // ABSTRACTION
    {
        transform.Translate(Vector3.left * speed / 10);
    }
    bool isPlayerPassed() // ABSTRACTION
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (transform.position.x < player.transform.position.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
