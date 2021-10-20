using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{
    public GameObject Cube;

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            Cube.GetComponent<NextLevelLoader>().KeyAmount++;
            Destroy(gameObject);
        }
    }

}
