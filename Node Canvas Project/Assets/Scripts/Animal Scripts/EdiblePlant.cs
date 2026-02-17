using UnityEngine;

public class EdiblePlant : MonoBehaviour
{
    public float foodValue = 10;
    RespawnPlant respawnScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        respawnScript = GetComponent<RespawnPlant>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one * foodValue * 0.2f;
        if (foodValue < 0)
        {
            respawnScript.Respawn();
            foodValue = 10;
        }
    }
}
