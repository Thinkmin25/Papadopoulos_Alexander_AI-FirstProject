using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using UnityEngine;

public class DamManager : MonoBehaviour
{
    public Blackboard beaverBB;
    public float damBuildValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beaverBB = GetComponent<Blackboard>();
        beaverBB.SetVariableValue("DamGO", this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
