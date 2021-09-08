using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{

    
    // Enter Contact
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "endGame")
        {
            print("End Game");
            SceneManager.LoadScene("winScene");
        }
    }
}
