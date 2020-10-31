using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNavMeshScript : MonoBehaviour
{
    public Transform[] points;
    public int destPoints = 0;
    public int searchDistance;
    public Transform target;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GotoNextPoint();

        //prints the distance between the robot and the player
        Debug.Log("Distance to player: " + Vector3.Distance(target.position, transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the distance variable, to be the distance between the player and the robot.
        var distance = Vector3.Distance(target.position, transform.position);

        //checks if the distance between the robot and the limit of it's search is true.
        if(distance <= searchDistance)
        {
            //makes the robot move towards it's target.
            agent.SetDestination(target.position);
        }

        else if (!agent.pathPending && agent.remainingDistance < 1f)
        {
            GotoNextPoint();
        }

    }

    void GotoNextPoint()
    {
        //returns if no points have been set up
        if (points.Length == 0)
            return;

        //makes the robot go to the current selected destination.
        agent.destination = points[destPoints].position;

        //picks the next point in the array at the destination, cycling to the start if needed.
        destPoints = (destPoints + 1) % points.Length;

    }
}
