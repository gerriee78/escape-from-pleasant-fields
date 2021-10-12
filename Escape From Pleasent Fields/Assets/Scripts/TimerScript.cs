using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public float timer = 10f;
    private Text timerSeconds;
    private float PreviousNumber; 

    // Start is called before the first frame update
    void Start()
    {
        timerSeconds = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //timerSeconds.text = timer.ToString("f0");
        if (timer <- 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //show number with decimals (this is just to make it seem faster/more urgent)
        int FrontNum = Mathf.RoundToInt(timer);
        float Number = Mathf.Round(timer*10) / 10;

        float difference = timer - PreviousNumber;

        if (Number.ToString().Length - FrontNum.ToString().Length == 0)
        {
            timerSeconds.text = (FrontNum.ToString() + ".0");
        }
        else
        {
            timerSeconds.text = Number.ToString();
        }



    }
}

