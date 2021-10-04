using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectionMeter : MonoBehaviour
{
    public float DetectionLevel;
    public bool IsSeen;
    Image image;
    [SerializeField]
    float healingAmount;
    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        image.fillAmount = DetectionLevel;
        if (DetectionLevel < 0)
        {
            //reload scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(IsSeen == false)
        {
            DetectionLevel += healingAmount * Time.deltaTime;
        }
    }
   




}
