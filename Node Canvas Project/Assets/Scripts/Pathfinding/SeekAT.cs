using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


namespace NodeCanvas.Tasks.Actions {

	public class SeekAT : ActionTask {
		public Transform targetTransform;
		private NavMeshAgent navAgent;
		public float seekFrequency;
		float timeSinceLastSeek = 0f;
		public BBParameter<Vector3> lastSeenPos;

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
            navAgent.SetDestination(targetTransform.position);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            timeSinceLastSeek += Time.deltaTime;

            if (timeSinceLastSeek > seekFrequency)
            {
				lastSeenPos.SetValue(targetTransform.position);
                navAgent.SetDestination(targetTransform.position);
                timeSinceLastSeek = 0f;
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