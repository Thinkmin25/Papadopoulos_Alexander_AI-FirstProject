using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundMask;
    NavMeshAgent navAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        bool leftMB = Mouse.current.leftButton.IsPressed(0);

        if (leftMB)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            //Vector3 mouseTarget = Camera.main.ScreenToWorldPoint(mousePos);
            Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);
            if (Physics.Raycast(mouseRay, out RaycastHit mouseHit, 30f, groundMask))
            {
                navAgent.SetDestination(mouseHit.point);
            }
        }
    }
}
