using System.Collections;
using UnityEngine;
using TMPro;

public class RespawnText : MonoBehaviour
{
    public TextMeshProUGUI respawnText;
    public float displayTime = 2.0f;

    void Awake()
    {
        Debug.Log("RespawnText script awake");
    }

    void Start()
    {
        // Disable the text at the start
        respawnText.enabled = false;
        Debug.Log("RespawnText script started");
    }

    public void ShowRespawnText()
    {
        Debug.Log("Showing Respawn Text");
        StartCoroutine(DisplayRespawnText());
    }

    IEnumerator DisplayRespawnText()
    {
        respawnText.enabled = true;
        Debug.Log("Respawn Text enabled");

        yield return new WaitForSeconds(displayTime);

        respawnText.enabled = false;
        Debug.Log("Respawn Text disabled after waiting");
    }
}
