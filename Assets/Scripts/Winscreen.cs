using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{

    public Text winText; // Reference to the UI Text component displaying the win message

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("win"))

        {
            ShowWinScreen();

        }

    }


    private void ShowWinScreen()

    {

        // Show the win text or perform other win-related actions

        winText.gameObject.SetActive(true);

    }

}