using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    public int IndexDestination;
    public Vector3 Destination;

    public float remainingDistanceOffset = 5.0f;
    
    public UnityEngine.AI.NavMeshAgent meshAgent;

    public void ProcessDestination(){
        meshAgent.SetDestination(Destination);
    }

    public bool IsDestinationHit()
    {
        return meshAgent.remainingDistance < remainingDistanceOffset;
    }

    public void RandomizeSpeed(float min, float max)
    {
        meshAgent.speed = Random.Range(min, max);
    }
    
    public float GetRemainingDistance() => meshAgent.remainingDistance;
}
