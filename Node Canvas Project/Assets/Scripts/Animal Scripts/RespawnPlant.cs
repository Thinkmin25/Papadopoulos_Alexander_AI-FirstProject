using UnityEngine;
using UnityEngine.AI;

public class RespawnPlant : MonoBehaviour
{
    NavMeshAgent navAgent;
    float respawnRangeL = 8;
    float respawnRangeW = 8;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        Vector3 respawnPos = new Vector3(Random.Range(-respawnRangeL, respawnRangeL), 0, Random.Range(-respawnRangeW, respawnRangeW));
        if ( NavMesh.SamplePosition(respawnPos, out var hit, 3, NavMesh.AllAreas))
        {
            navAgent.Warp(hit.position);
        }
    }
}
