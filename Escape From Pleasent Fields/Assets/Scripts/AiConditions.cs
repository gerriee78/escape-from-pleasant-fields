using System;
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
    [SerializeField]
    SpriteRenderer SR;
    [SerializeField]
    Vision vision;
    DetectionMeter health;
    bool visionBuffer;
    [SerializeField]
    private ConeRenderer CR;
    private Material CRmat;
    private Material SRmat;


    private void Start()
    {
        vision = GetComponent<Vision>();
        health = GameObject.FindGameObjectWithTag("DetectionMeter").GetComponent<DetectionMeter>();
        if (CR == null)
        {
            try
            {
                SR = gameObject.GetComponentInChildren<SpriteRenderer>();

                SRmat = SR.material;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            try
            {
                CR = transform.parent.GetComponentInChildren<ConeRenderer>();
                CRmat = CR.gameObject.GetComponent<Renderer>().material;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }



        }
        try
        {
            SR = gameObject.GetComponentInChildren<SpriteRenderer>();

            SRmat = SR.material;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        try
        {
            CR = transform.parent.GetComponentInChildren<ConeRenderer>();
            CRmat = CR.gameObject.GetComponent<Renderer>().material;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        vision = GetComponent<Vision>();
        health = GameObject.FindGameObjectWithTag("DetectionMeter").GetComponent<DetectionMeter>();


        if (Condition == AiCondition.StayStill)
        {
            try
            {
                CRmat.color = new Vector4(0, 0.6039216f, 0.5568628f, 0.6f);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            SR.color = new Vector4(0, 0.6039216f, 0.5568628f, 0.6f);
        }
        else if (Condition == AiCondition.KeepMoving)
        {

            try
            {

                CRmat.color = new Vector4(0.8113208f, 0.4837631f, 0.1637949f, 0.6f);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            SR.color = new Vector4(0.8113208f, 0.4837631f, 0.1637949f, 0.6f);

        }
        else if (Condition == AiCondition.Unconditional)
        {
            try
            {
                CRmat.color = new Vector4(0.6320754f, 0.1633855f, 0.1633855f, 0.6f);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            SR.color = new Vector4(0.8113208f, 0.4837631f, 0.1637949f, 0.6f);

        }
        else if (Condition == AiCondition.Heal)
        {
            try
            {
                CRmat.color = new Vector4(0.1576159f, 0.3867925f, 0.151068f, 0.6f);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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
