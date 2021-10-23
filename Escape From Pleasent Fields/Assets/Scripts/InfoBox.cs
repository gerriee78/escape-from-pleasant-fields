using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoBox : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI tmp;
    [SerializeField]
    GameObject Textbox;
    [SerializeField]
    string message;

    // Start is called before the first frame update
    void Start()
    {
        Textbox.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Textbox.SetActive(true);
            tmp.text = message; 
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        Textbox.SetActive(false);
    }
}
