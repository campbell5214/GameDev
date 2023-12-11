using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public bool isGrounded = true;
    // Start is called before the first frame update
    void OnCollisionEnter2D()
    {
            isGrounded = true;
    }

    void OnCollisionExit2D()
    {
            isGrounded = false;
    }

    void OnCollisionStay2D()
    {
            isGrounded = true;
    }
}
