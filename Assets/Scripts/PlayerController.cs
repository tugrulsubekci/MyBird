using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    protected float force = 5; // ENCAPSULATION

    private GameManager gameManager;

    public virtual void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameManager.gameOver)
        {
            Fly();
        }
    }

    void Fly()
    {
        playerRb.AddForce(Vector3.up * force ,ForceMode.Impulse);
    }
}
