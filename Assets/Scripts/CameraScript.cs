using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        // Follow the player's position horizontally and vertically with an offset
        float offsetY = 60.0f; // Adjust this value to set the desired offset
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + offsetY, -90);
    }
}
