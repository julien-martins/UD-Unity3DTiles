using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class Simulation
{
    public int id = 0;
    public List<NodePath> path;
    public int MaxNumberOfPeople;
    public int TotalNumberOfPeople;
    public bool repeat;

    public float minDelayBetweenPeople = 1.0f;
    public float maxDelayBetweenPeople = 3.0f;

    public float minPeopleSpeed = 3.5f;
    public float maxPeopleSpeed = 6.0f;
    
    [NonSerialized] public List<People> peopleGo = new();

    [NonSerialized] public int currentNumberOfPeople = 0;
    [NonSerialized] public int currentTotalNumberOfPeople = 0;
    
    [NonSerialized] public float peopleSpawnerTimer = 0.0f;
    [NonSerialized] public float peopleSpawnerDelay = 0.0f;
}

public class CrowdSimulator : MonoBehaviour
{
    [SerializeField] GameObject peoplePrefab;

    [SerializeField] List<Simulation> _simulations;

    List<Transform> _simTransform = new();
    
    // Start is called before the first frame update
    void Start()
    {
        InitSimulation(_simulations[0]);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSimulation(_simulations[0]);
    }

    void InitSimulation(Simulation sim)
    {
        var go = new GameObject();
        go.name = "Simulation " + sim.id;
        go.transform.parent = transform;
        _simTransform.Add(go.transform);
        
        ResetSimTimer(sim);
    }
    
    void UpdateSimulation(Simulation sim)
    {
        sim.peopleSpawnerTimer += Time.deltaTime;

        if(sim.currentNumberOfPeople < sim.MaxNumberOfPeople && 
           (sim.repeat || sim.currentTotalNumberOfPeople < sim.TotalNumberOfPeople) &&
           sim.peopleSpawnerTimer > sim.peopleSpawnerDelay ) {
            //Create a new people
            var n = Instantiate(peoplePrefab, sim.path[0].transform.position, Quaternion.identity);
            n.transform.parent = _simTransform[sim.id];
            var p = n.GetComponent<People>();
            
            p.RandomizeSpeed(sim.minPeopleSpeed, sim.maxPeopleSpeed);
            
            sim.currentNumberOfPeople++;
            sim.currentTotalNumberOfPeople++;
            

            //Assign to the new people the first destination
            p.IndexDestination = 1;
            if(p.IndexDestination < sim.path.Count)
                p.Destination = sim.path[p.IndexDestination].transform.position;
            
            //Add people to this sim
            sim.peopleGo.Add( p );
            
            //Make move the agent
            p.ProcessDestination();
            
            ResetSimTimer(sim);
        }
        
        //Test all people in the sim and check if they are goal his checkpoint
        // Continue the path if it can else destroy it
        List<People> toDestroy = new();
        foreach (var p in sim.peopleGo)
        {
            Debug.Log(sim.path.Count);
            
            if (!p.IsDestinationHit()) continue;
            if (p.IndexDestination + 1 >= sim.path.Count)
            {
                toDestroy.Add(p);
                continue;
            }

            p.IndexDestination++;
            p.Destination = sim.path[p.IndexDestination].transform.position;
            p.ProcessDestination();
        }
        
        //Destoy all people who finish his path
        foreach (var p in toDestroy)
        {
            sim.peopleGo.Remove(p);
            Destroy(p.gameObject);
            sim.currentNumberOfPeople--;
            if (sim.currentNumberOfPeople < 0)
                sim.currentNumberOfPeople = 0;
        }
        

    }

    public void ResetSimTimer(Simulation sim)
    {
        sim.peopleSpawnerTimer = 0.0f;
        sim.peopleSpawnerDelay = Random.Range(sim.minDelayBetweenPeople, sim.maxDelayBetweenPeople);
    }
}
