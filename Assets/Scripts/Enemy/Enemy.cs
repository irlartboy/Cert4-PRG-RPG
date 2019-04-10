using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum State
    {
        Patrol,
        Seek
    }
    public State currentState;
    public Transform waypointParent;
    public float moveSpeed = 2f;
    public float stoppingDistance = 1f;

    private Transform[] waypoints;
    private int currentIndex = 1;
    private NavMeshAgent agent;
    private Transform target;

   
    void Start()
    {
        // Get the children from WaypointParent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();

        // Get the AI component
        agent = GetComponent<NavMeshAgent>();

        // just in case make starting  state Patrol
        currentState = State.Patrol;
    }

    
    void Update()
    {
        // Run Patrol Every Frame
        

        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Seek:
                Seek();
                break;
           default:
                break;

        }
    }

    void OnDrawGizmosSelected()
    {
        // If waypoints is not null AND waypoints is not empty
        if (waypoints != null && waypoints.Length > 0)
        {
            // Get current waypoint
            Transform point = waypoints[currentIndex];
            // Draw line from position to waypoint
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, point.position);
            // Draw stopping distance sphere
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(point.position, stoppingDistance);
        }
    }

    void Patrol()
    {
        // 1 - Get the current waypoint
        Transform point = waypoints[currentIndex];

        // 2 - Get distance from waypoint
        float distance = Vector3.Distance(transform.position, point.position);
        
        // 3 - If distance is less than stopping distance
        if (distance < stoppingDistance)
        {
            // 4 - Move to next waypoint
            currentIndex++;
            // 4.1 - If currentIndex >= waypoints.Length
            if (currentIndex >= waypoints.Length)
            {
                // 4.2 - Set currentIndex to 1
                currentIndex = 1;
            }
        }

        // 5 - Translate Enemy towards current waypoint
        //transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);
        //transform.LookAt(point.position);

        // 5 - Use NavMeshAgent to follow the current waypoint
        agent.SetDestination(point.position);
    }
     void Seek()
    {
        // Get enemy to follow target
        agent.SetDestination(target.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //set state to thing in our zone
            target = other.transform;
            //switch state to seek
            currentState = State.Seek;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        // switch state back to patrol as we lost our target
        if (other.gameObject.CompareTag("Player"))
        {
            //switch state to back to patrol
            currentState = State.Patrol;
        }
    }
}
