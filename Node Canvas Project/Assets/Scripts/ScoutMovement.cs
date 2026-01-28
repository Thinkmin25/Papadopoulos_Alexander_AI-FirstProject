using UnityEngine;
using UnityEngine.AI;

public class ScoutMovement : MonoBehaviour
{
    public NavMeshAgent navAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navAgent.SetDestination(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
