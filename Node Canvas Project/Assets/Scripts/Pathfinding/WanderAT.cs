using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class WanderAT : ActionTask {

		public float wanderRadius;
		public float wanderCircleDistance;
		public NavMeshAgent navAgent;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			FindWanderSpot();
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			VisualizeWander(agent.transform.position, navAgent.destination, 0);
			if (navAgent.remainingDistance < 0.25f)
			{
				FindWanderSpot();
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		void FindWanderSpot()
		{
            Vector3 circleCenter = agent.transform.position + agent.transform.forward * wanderCircleDistance;
            Vector3 randomPoint = Random.insideUnitCircle.normalized * wanderRadius;
            Vector3 destination = circleCenter + new Vector3(randomPoint.x, agent.transform.position.y, randomPoint.z);

            if (NavMesh.SamplePosition(destination, out var hit, 10, NavMesh.AllAreas))
            {
				navAgent.SetDestination(hit.position);
            }
        }

		void VisualizeWander(Vector3 P1, Vector3 P2, float updateFrequency)
		{
			Debug.DrawLine(P1, P2);
			
			for (int i=0; i<16; i++)
			{
				Debug.DrawLine(P2 + new Vector3(Mathf.Cos(i * 2 * Mathf.PI / 16) * wanderRadius, agent.transform.position.y, Mathf.Sin(i * 2 * Mathf.PI / 16) * wanderRadius), P2 + new Vector3(Mathf.Cos((i + 1) % 16 * 2 * Mathf.PI / 16) * wanderRadius, agent.transform.position.y, Mathf.Sin((i + 1) % 16 * 2 * Mathf.PI / 16) * wanderRadius));

            }
		}
	}
}