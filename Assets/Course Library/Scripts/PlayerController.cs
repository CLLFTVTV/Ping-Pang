using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    private Animator playerAnim;
    public bool gameOver;
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Translate player according to left/right input
        float input = Input.GetAxis("Horizontal");
        

        //Keep in bounds
        if (transform.position.x > 8.85)
        {
            transform.position = new Vector3(8.85f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -8.85)
        {
            transform.position = new Vector3(-8.85f, transform.position.y, transform.position.z);
        }

        //Running animation on move
        if (input != 0)
        {
            playerAnim.SetFloat("Speed_f", 1);
        } else
        {
            playerAnim.SetFloat("Speed_f", 0);
        }

        //Rotate and move
        if (input > 0 && !gameOver)
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
            transform.Translate(Vector3.forward * Time.deltaTime * input * speed);
        } else if (input < 0 && !gameOver)
        {
            transform.localEulerAngles = new Vector3(0, -90, 0);
            transform.Translate(Vector3.back * Time.deltaTime * input * speed);
        } else
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        //Shoot
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Ball_S") || collision.gameObject.CompareTag("Ball_XS"))
        {
            explosion.Play();

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            gameOver = true;
        }
    }
}
