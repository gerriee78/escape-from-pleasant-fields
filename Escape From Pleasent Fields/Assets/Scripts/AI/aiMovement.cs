using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiMovement : MonoBehaviour
{
    
    enum MovementType {Still, Swivel, Patrol}
    
    [SerializeField]
    MovementType movementType;

    [Header("Patrol Values")]
    [SerializeField]
    [Tooltip("The ai will patrol these points if in patrol mode")]
    Transform[] PatrolPoints;
    [Header("Swivel Values")]
    [SerializeField]
    float SwivelSpeed;
    [SerializeField]
    float SwivelAngle;
    bool SwivelTracker;
    float swivelDirection = 1;
    Vector2 direction;
    NavMeshAgent agent;
    int CurrentPoint;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Vector3 foward = transform.forward;
        direction = new Vector2(foward.x, foward.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (movementType == MovementType.Patrol)
        {
            //If the player is at the target destination, set the next point in the array to be the current destination.
            if (Mathf.Round(transform.position.x * 100) / 100 == Mathf.Round(PatrolPoints[CurrentPoint].position.x * 100) / 100 && Mathf.Round(transform.position.z * 100) / 100 == Mathf.Round(PatrolPoints[CurrentPoint].position.z * 100) / 100)
            {
                CurrentPoint++;
                if (CurrentPoint > PatrolPoints.Length - 1)
                {
                    CurrentPoint = 0;
                }
                
            }
            agent.destination = PatrolPoints[CurrentPoint].position;
        }
        if (movementType == MovementType.Swivel)
        {
            //apply rotation in direction
            transform.Rotate(new Vector3(0, swivelDirection* SwivelSpeed * Time.deltaTime, 0));
            Vector3 foward = transform.forward;
            //Debug.Log(Vector2.Angle(new Vector2(foward.x, foward.z), direction));
            if (Vector2.Angle(new Vector2(foward.x, foward.z), direction) >= SwivelAngle && SwivelTracker == false)
            {
                swivelDirection *= -1;
                SwivelTracker = true;
            }
            else if(Vector2.Angle(new Vector2(foward.x, foward.z), direction) < SwivelAngle)
            {
                SwivelTracker = false;
            }
        }


    }
}
