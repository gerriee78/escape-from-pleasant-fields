using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showText : MonoBehaviour
{ 
    public GameObject text;
    public GameObject player; 

    // Update is called once per frame
    void Update()
    {
        text.transform.position = player.transform.position; 
    }
}
