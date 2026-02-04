using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class FleeAT : ActionTask {
		public float fleeingDistance;
		public LayerMask seekerMask;
		NavMeshAgent navAgent;
		public BBParameter<Vector3> fleePos;

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

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Collider[] seekerArray = Physics.OverlapSphere(agent.transform.position, fleeingDistance, seekerMask);
			Vector3 escapePos = Vector3.zero;
			float escapeDist = 0;

            if (seekerArray.Length > 0)
			{
				foreach (Collider col in seekerArray)
				{
					escapePos += col.transform.position - agent.transform.position;
					if (Vector3.Distance(agent.transform.position, col.transform.position) > escapeDist)
					{
						escapeDist = Vector3.Distance(agent.transform.position, col.transform.position);

                    }
				}
				fleePos.SetValue(escapePos.normalized * (escapeDist));
				EndAction();
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