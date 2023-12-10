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

    public float KBForce;
    public float KBCOunter;
    public float KBCTotalTime;
    public bool KnockFromRIght;

    private PlayerHealth playerHealth;
    //private Animator playerAnim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>(); // Assuming PlayerHealth script is attached to the same GameObject
        //playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (KBCOunter <= 0)
        {
            move = Input.GetAxis("Horizontal");
            //Debug.Log(move);

            if (move != 0)
            {
                //playerAnim.SetBool("isWalking", true);
            } 
            else
            {
                //playerAnim.SetBool("isWalking", false);
            }

            rb.velocity = new Vector2(speed * move, rb.velocity.y);
        }
        else
        {
            if (KnockFromRIght)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            else
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }

            KBCOunter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            isGrounded = false;
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
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            // Assuming SetRespawnPoint takes a Vector3 argument
            Vector3 newRespawnPoint = other.transform.position;
            playerHealth.SetRespawnPoint(newRespawnPoint);
            transform.position = newRespawnPoint;
        }
    }
}
