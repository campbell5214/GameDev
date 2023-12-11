using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject tx;

    // Start is called before the first frame update
    public void endGame()
    {
        tx.SetActive(true);
    }
}
