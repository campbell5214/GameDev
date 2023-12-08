using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class playerController : MonoBehaviour
{

    public float speed;

    public float jump;

    private float move;

    private bool isGrounded;

    private Rigidbody2D rb;


    void Start() { rb = GetComponent<Rigidbody2D>(); }

    void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * move, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && isGrounded)

        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);            // Set isGrounded to false immediately after the jump            isGrounded = false;

        }
    }


    void OnCollisionEnter2D(Collision2D other)

    {

        if (other.gameObject.CompareTag("Ground"))

        {

            isGrounded = true;

        }

    }


    void OnCollisionExit2D(Collision2D other)

    {

        if (other.gameObject.CompareTag("Ground"))

        {

            isGrounded = false;

        }

    }


    void OnCollisionStay2D(Collision2D other)

    {

        if (!isGrounded && other.gameObject.CompareTag("Ground"))

        {

            // Additional check in case OnCollisionEnter2D didn't catch it

            isGrounded = true;

        }

    }

}