using System.Collections;
using UnityEngine;

// Quits the player when the user hits escape

public class InGameExit : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
            //Debug.Log("Exit Game (esc)");
        }
    }
}
