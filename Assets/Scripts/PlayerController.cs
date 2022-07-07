using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float force = 5; // ENCAPSULATION

    private GameManager gameManager;
    private Animator playerAnim;

    private int timeBetweenSpace = 0;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAnim = GetComponent<Animator>();
        Flap(false);
        StartCoroutine(SpaceTimer());
        playerRb.useGravity = false;
    }

    void Update()
    {
        // Keyboard
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

        // Touch
        if (Input.touchCount > 0 && !gameManager.gameOver)
        {
            Touch firstTouch = Input.touches[0];
            if(firstTouch.phase == TouchPhase.Began)
            {
                Fly();
                Flap(true);
                timeBetweenSpace = 0;
                if (!playerRb.useGravity)
                {
                    playerRb.useGravity = true;
                }
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
        FindObjectOfType<AudioManager>().Play("Flap");
    }
    void Flap(bool isFlapping)
    {
        playerAnim.SetBool("Flapping", isFlapping);
    }
    IEnumerator SpaceTimer()
    {
        while (!gameManager.gameOver)
        {
            yield return new WaitForSeconds(1);
            timeBetweenSpace++;
        }
    }
}
