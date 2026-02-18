using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class LocateAT : ActionTask {

		float sightRange = 1;
		public float growRate = 5;
		NavMeshAgent navAgent;
		int layerMask = 1 << 9;

		public BBParameter<bool> foundTarget;
		public BBParameter<GameObject> targetGO;

		public BBParameter<float> foodNeed;
		public BBParameter<float> foodThreshold;
		public BBParameter<float> teethNeed;
		public BBParameter<float> teethThreshold;
		public BBParameter<float> woodInventory;
		public BBParameter<GameObject> dam;

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
            sightRange = 1;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			if (woodInventory.value > 0)
			{
				layerMask = 1 << 11;
			}
			else if (teethNeed.value < teethThreshold.value)
			{
				layerMask = 1 << 10;
			}
			else if (foodNeed.value < foodThreshold.value)
			{
				layerMask = 1 << 9;
			}

				sightRange += Time.deltaTime * growRate;
			if (!navAgent.hasPath)
			{
                Debug.Log(navAgent.hasPath + " " + sightRange);
                if (Physics.SphereCast(agent.transform.position, sightRange, Vector3.one, out var hit, 0.5f, layerMask, QueryTriggerInteraction.Collide))
                {
                    Debug.Log("cool " + hit.point + hit.collider);
					NavMesh.SamplePosition(hit.point, out var target, 5, NavMesh.AllAreas);
					if (navAgent.SetDestination(target.position))
					{
						targetGO.SetValue(hit.collider.gameObject);
						Debug.Log(target.position);
                        foundTarget.SetValue(true);
                    }
                    Debug.Log(navAgent.hasPath + " " + navAgent.destination);
                    
                }
            }
			
			
            for (int i = 0; i < 16; i++)
            {
                Debug.DrawLine(agent.transform.position - agent.transform.up + new Vector3(Mathf.Cos(i * 2 * Mathf.PI / 16) * sightRange, agent.transform.position.y, Mathf.Sin(i * 2 * Mathf.PI / 16) * sightRange), agent.transform.position - agent.transform.up + new Vector3(Mathf.Cos((i + 1) % 16 * 2 * Mathf.PI / 16) * sightRange, agent.transform.position.y,Mathf.Sin((i + 1) % 16 * 2 * Mathf.PI / 16) * sightRange));

            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}