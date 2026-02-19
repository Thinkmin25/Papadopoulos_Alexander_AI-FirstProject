using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using UnityEngine;

public class DamManager : MonoBehaviour
{
    public FSM beaverFSM;
    public float damBuildValue = 0;
    public int beaverHideCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beaverFSM.blackboard.SetVariableValue("DamGO", this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(3 + damBuildValue / 33, 3 + damBuildValue / 33, 1.5f + damBuildValue / 33);
    }
}
