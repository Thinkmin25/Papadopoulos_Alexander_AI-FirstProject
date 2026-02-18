using UnityEngine;

public class EdiblePlant : MonoBehaviour
{
    public float resourceValue = 10;
    RespawnPlant respawnScript;
    public bool isTree;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        respawnScript = GetComponent<RespawnPlant>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localScale = Vector3.one * resourceValue * 0.2f;
        if (resourceValue < 0)
        {
            respawnScript.Respawn();
            resourceValue = 10;
        }
    }
}
