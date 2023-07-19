using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ball;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBall", 2, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBall()
    {
        if (playerController.gameOver != true)
        {
            float rangeX = Random.Range(-10, 10);
            Instantiate(ball, new Vector3(rangeX, 13, 0), Quaternion.identity);
        }
    }
}
