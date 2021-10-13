using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject objToDestroy;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            DestroyObject(objToDestroy);

    }
}
