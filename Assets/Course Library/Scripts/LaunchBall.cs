using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    private Rigidbody ballRb;
    public GameObject smallBall;
    public GameObject xSmallBall;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();

        //Launch ball in random direction at spawn
        float dir = Random.Range(0, 10);

        if (dir % 2 == 0)
        {
            ballRb.AddForce(Vector3.right * 5, ForceMode.Impulse);
        } else
        {
            ballRb.AddForce(Vector3.left * 5, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destory ball and spawn smaller balls
        if (collision.gameObject.CompareTag("Ball")
            || collision.gameObject.CompareTag("Ball_S")
            || collision.gameObject.CompareTag("Ball_XS")
            || collision.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        } else if (collision.gameObject.CompareTag("Bullet"))
        {
            if (gameObject.CompareTag("Ball"))
            {
                Instantiate(smallBall, transform.position, Quaternion.identity);
                Instantiate(smallBall, transform.position, Quaternion.identity);
            } else if (gameObject.CompareTag("Ball_S"))
            {
                Instantiate(xSmallBall, transform.position, Quaternion.identity);
                Instantiate(xSmallBall, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
