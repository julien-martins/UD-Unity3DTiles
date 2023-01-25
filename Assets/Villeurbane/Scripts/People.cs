using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    public int IndexDestination;
    public Vector3 Destination;

    public float remainingDistanceOffset = 5.0f;
    
    public UnityEngine.AI.NavMeshAgent meshAgent;
    public AudioSource audioSource;

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

    public void UnmuteAudio()
    {
        audioSource.mute = false;
    }

    public void MuteAudio()
    {
        audioSource.mute = true;
    }
    
    public float GetRemainingDistance() => meshAgent.remainingDistance;
}
