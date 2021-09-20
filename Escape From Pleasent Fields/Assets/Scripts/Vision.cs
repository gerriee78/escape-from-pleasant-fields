using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField]
    public LayerMask interactable;
    [SerializeField]
    [Tooltip("How far can it see")]
    public float seeDistance;
    public float visionAngle;

    Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 1, Color.magenta);

        RaycastHit lineinfo;
        Physics.Linecast(transform.position, player.transform.position, out lineinfo, interactable);

        //Calculate distance without y axis. 
        Vector3 distance = transform.position - new Vector3(player.position.x, transform.position.y, player.position.z);
        float Distance = distance.magnitude;
        //Debug.Log(Distance);
        
        //Calculate angle without y axis.
        float angle = Vector3.Angle(Vector3.forward, -distance);
        Debug.Log(angle);



        //check if the player is within vision range of the nurse.
        if (Distance < seeDistance && lineinfo.collider.tag == "Player" && angle < visionAngle)
        {
            Debug.DrawLine(transform.position, player.position, Color.blue);
        }
        else
        {
            Debug.DrawLine(transform.position, player.position, Color.red);
        }
    }
}
