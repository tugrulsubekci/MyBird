using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjects; // ENCAPSULATION

    private GameManager gameManager;

    private float yRange = 2;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        SpawnPlayer(DataManager.Instance.playerIndex);
        StartCoroutine(SpawnObstacleRoutine());
    }

    void SpawnObstacle() // ABSTRACTION
    {
        if(gameManager.isTouch)
        {
            float randomX = Random.Range(-yRange, yRange);
            Vector3 obstacleSpawnPos = new Vector3(5, randomX, 0);
            Instantiate(gameObjects[0], obstacleSpawnPos, gameObjects[0].transform.rotation);
        }
        else
        {
            return;
        }
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (!gameManager.gameOver)
        {
            yield return new WaitForSeconds(2);
            SpawnObstacle();
        }
    }
    void SpawnPlayer(int playerIndex)
    {
        Vector3 playerPos = new Vector3(0, 10, 0);
        Instantiate(gameObjects[playerIndex], playerPos, gameObjects[playerIndex].transform.rotation);
    }
}
