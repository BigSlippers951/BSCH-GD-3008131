
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolScript : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;

    public Transform[] goal;
    public GameObject player;
    public float detectRadius;

    public bool playerDetected;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal[0].position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //checks if player is in range
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= detectRadius)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }
        {

        }
        // once the agent reaches the goal, it will go to the next goal

        if (agent.remainingDistance < 0.5f && playerDetected == false)
        {
            agent.destination = goal[Random.Range(0, goal.Length)].position;
        }
        // if the player is detected, the agent will go to the player's position
        else if (playerDetected == true)
        {
            agent.destination = player.transform.position;
        }

    }
}
