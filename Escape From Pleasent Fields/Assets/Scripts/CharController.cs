using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField]
    float moverSpeed = 4f;
    
    //[SerializeField]
    //private Transform model;
    Vector3 forward, right;
    [SerializeField]
    private Transform model;
    // Start is called before the first frame update
    void Start()
    {
        
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
            Move();
    }

    void Move()
    {

        //model.rotation = Quaternion.RotateTowards()
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        direction = direction.normalized;
        transform.Translate(direction * moverSpeed * Time.deltaTime);
        
        
        

    }

}

