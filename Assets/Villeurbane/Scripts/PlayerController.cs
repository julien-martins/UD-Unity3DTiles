using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    public List<Transform> path;

    private int pathIndex = 0;
    private bool stop = false;

    void Start()
    {
        navMeshAgent.SetDestination(path[pathIndex].position);
        pathIndex++;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance < 10.0f && !stop)
        {
            navMeshAgent.SetDestination(path[pathIndex].position);
            pathIndex++;

            if (pathIndex >= path.Count) stop = true;
        }
    }
}
