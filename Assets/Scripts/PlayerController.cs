using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    protected float force = 5; // ENCAPSULATION

    private GameManager gameManager;
    private Animator playerAnim;

    int timeBetweenSpace = 0;
    public virtual void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAnim = GetComponent<Animator>();
        Flap(false);
        StartCoroutine(spaceTimer());
        playerRb.useGravity = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameManager.gameOver)
        {
            Fly();
            Flap(true);
            timeBetweenSpace = 0;
            if(!playerRb.useGravity)
            {
                playerRb.useGravity=true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (gameManager.gameOver)
        {
            Flap(false);
        }
        if (timeBetweenSpace >= 1)
        {
            Flap(false);
        }
    }
    void Fly()
    {
        playerRb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
    void Flap(bool isFlapping)
    {
        playerAnim.SetBool("Flapping", isFlapping);
    }
    IEnumerator spaceTimer()
    {
        while (!gameManager.gameOver)
        {
            yield return new WaitForSeconds(1);
            timeBetweenSpace++;
        }
    }
}
