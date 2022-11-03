using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour

{

//jumping power for the player object.
[Header("Defualt jumping power")]
public float jumpPower = 3f;

//True or false if the object is on the ground/floor
[Header("Boolean isGrounded")]
public bool isGrounded = true;

//position of the object (player?)
float posX = 0.0f;

//rigidbody2D of the object (player?)
Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {

        //Variable rb equals to the rigidbody2D component
        rb = transform.GetComponent<Rigidbody2D>();

        //variable posX equals  to the position of the object on the x axis
        posX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if the space bar is press and the object is on the ground and the game is playing. (...)
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            //adds force to the object to jump upwards based on jump power, mass, and gravitational pull (GRAVITY)
            rb.AddForce(Vector3.up * (jumpPower * rb.mass * rb.gravityScale * 20.0f));

        }

        if (transform.position.x < posX)
        {
            GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //If colliders tag equals the ground
        if (collision.collider.tag == "Ground")
        {
            //isGrounded equals True
            isGrounded = true;

        }

        if (collision.collider.tag == "Enemy")
        {
            GameOver();
        }
    }

    void GameOver()
    {

        //Game over function is acalled from the game controller
        GameObject.Find("GameController").GetComponent<GameController>().GameOver();


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            GameObject.Find("GameController").GetComponent<GameController>().IncrementScore();
            Destroy(collision.gameObject);

        }
    }
}
