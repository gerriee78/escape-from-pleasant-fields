using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiMovement : MonoBehaviour
{
    [SerializeField]
    Transform[] PatrolPoints;
    NavMeshAgent agent;
    int CurrentPoint;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Round(transform.position.x*100)/100 == Mathf.Round(PatrolPoints[CurrentPoint].position.x * 100) / 100 && Mathf.Round(transform.position.x * 100) / 100 == Mathf.Round(PatrolPoints[CurrentPoint].position.x * 100) / 100)
        {
            CurrentPoint++;
            if(CurrentPoint > PatrolPoints.Length-1)
            {
                CurrentPoint = 0;
            }
        }
        agent.destination = PatrolPoints[CurrentPoint].position;


    }
}
