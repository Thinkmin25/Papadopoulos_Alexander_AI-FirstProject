using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class NPCTypeIdlingAT : ActionTask {

		public float idleMax;
		public float idleMin;
		public float idleTimer;
		public float actionSpeed;
		Transform startingTransform;
		Vector3 targetVector;
		int actionType;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			idleTimer = 0f;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			

			switch (actionType)
			{
				case 0:
                    idleTimer -= Time.deltaTime;
                    if (idleTimer < 0)
                    {
						startingTransform = agent.transform;
                        targetVector = new Vector3(Random.Range(-170, 170), 0, Random.Range(-170, 170));
                        actionType = Random.Range(1, 3);
                    }
                    break;
				case 1:
					
					break;
				case 2:

					break;
				case 3:

					break;
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