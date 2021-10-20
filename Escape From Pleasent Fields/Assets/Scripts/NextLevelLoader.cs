using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    public float KeyAmount = 0;
    [SerializeField] private float _requiredKeyAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && KeyAmount >= _requiredKeyAmount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }

}
