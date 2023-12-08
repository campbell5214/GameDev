using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        // Follow the player's position horizontally and vertically
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -100);
    }
}
