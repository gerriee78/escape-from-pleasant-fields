using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nurseCollision : MonoBehaviour

{
    public GameObject text;
    Rigidbody rb;
    public float threshold = 1;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    // First Contact
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "nurse")
        {
            print("Contact");
            print("x "+Mathf.Abs(rb.velocity.x) + " z " + Mathf.Abs(rb.velocity.z));


            if ( Mathf.Abs( rb.velocity.x ) == 0 && Mathf.Abs(rb.velocity.z) == 0)
            {
                print("stationary Contact");
                
            } else
            {
                SceneManager.LoadScene("failScene");
                print("moving Contact");

            }
        }
    }

    // In Contact
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "nurse")
        {
            print("In Contact");
            print("x " + Mathf.Abs(rb.velocity.x) + " z " + Mathf.Abs(rb.velocity.z));


            if (Mathf.Abs(rb.velocity.x) == 0 && Mathf.Abs(rb.velocity.z) == 0)
            {
                print("stationary Contact");
                text.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("failScene");
                print("moving Contact");
            }
        }
    }
    // Exit Contact
        void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "nurse")
        {
            print("Exit Contact");
            text.SetActive(false);
        }
    }
}
