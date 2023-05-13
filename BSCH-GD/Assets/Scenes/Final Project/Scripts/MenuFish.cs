using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFish : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;

    public Transform[] goal;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            agent.destination = goal[Random.Range(0, goal.Length)].position;
        }
    }
}
