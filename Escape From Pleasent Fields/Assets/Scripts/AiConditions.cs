using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiConditions : MonoBehaviour
{
 enum AiCondition {StayStill,KeepMoving,Unconditional,Call,Heal}
    [SerializeField]
    AiCondition Condition;
    [SerializeField]
    float damage;

    SpriteRenderer SR;
    Vision vision;
    DetectionMeter health;
    bool visionBuffer; 


    private void Start()
    {
        SR = gameObject.GetComponentInChildren<SpriteRenderer>();
        vision = GetComponent<Vision>();
        health = GameObject.FindGameObjectWithTag("DetectionMeter").GetComponent<DetectionMeter>();

        if (Condition == AiCondition.StayStill)
        {
            SR.color = new Vector4(0, 0.6039216f, 0.5568628f, 0.6f);
        }
        else if (Condition == AiCondition.KeepMoving)
        {
            SR.color = new Vector4(0.8113208f, 0.4837631f, 0.1637949f, 0.6f);
        }
        else if (Condition == AiCondition.Unconditional)
        {
            SR.color = new Vector4(0.6320754f, 0.1633855f, 0.1633855f, 0.6f);
        }
        else if (Condition == AiCondition.Heal)
        {
            SR.color = new Vector4(0.1576159f, 0.3867925f, 0.151068f, 0.6f);
        }
    }


    private void Update()
    {
        if (vision.LOS == true)
        {
            visionBuffer = true;
            health.IsSeen = true;
            if (Condition == AiCondition.StayStill)
            {
                if (Input.GetAxis("HorizontalKey") + Input.GetAxis("VerticalKey") != 0)
                { 
                    health.DetectionLevel = health.DetectionLevel - damage * Time.deltaTime;

                }       
            }
            else if (Condition == AiCondition.KeepMoving)
            {
                if (Mathf.Abs(Input.GetAxisRaw("HorizontalKey"))  + Mathf.Abs(Input.GetAxisRaw("VerticalKey")) == 0)
                {
                    health.DetectionLevel = health.DetectionLevel - damage * Time.deltaTime;

                }
            }
            else if (Condition == AiCondition.Unconditional)
            {
                health.DetectionLevel = health.DetectionLevel - damage * Time.deltaTime;
            }
            else if (Condition == AiCondition.Heal) 
            {
                health.DetectionLevel = health.DetectionLevel + damage * Time.deltaTime;
            }
        }



        else
        {
            if(visionBuffer == true)
            {
                health.IsSeen = false;
            }
        }
    }


}
