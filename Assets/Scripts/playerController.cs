using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class playerController : MonoBehaviour
{
    public groundCheck gC;
    public float speed;
    public float jump;
    public UnityEvent end;

    private float move;
    private bool isGrounded;
    private Rigidbody2D rb;

    public float KBForce;
    public float KBCOunter;
    public float KBCTotalTime;
    public bool KnockFromRIght;

    private PlayerHealth playerHealth;
    //private Animator playerAnim;
    private int maxJump = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>(); // Assuming PlayerHealth script is attached to the same GameObject
        //playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = gC.isGrounded;
        
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

        if (Input.GetButtonDown("Jump") && maxJump>0)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            maxJump--;
        }
        

        if(Input.GetButton("Escape"))
        {
            Application.Quit();
        }

        if(isGrounded)
        {
            maxJump = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Heart"))
        {
            playerHealth.TakeDamage(-10);
        }
        if(collision.collider.CompareTag("End"))
        {
            end.Invoke();
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
