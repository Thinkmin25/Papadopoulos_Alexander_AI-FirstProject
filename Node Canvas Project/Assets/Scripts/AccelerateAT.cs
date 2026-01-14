using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AccelerateAT : ActionTask {
		public BBParameter<GameObject> otherObject;
		public float amountToAccelerate;
		float currentSpeed = 0;

		public Blackboard otherBlackboard;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			otherBlackboard = otherObject.value.GetComponent<Blackboard>();
			currentSpeed = otherBlackboard.GetVariableValue<float>("speed");
			currentSpeed += amountToAccelerate * Time.deltaTime;
			otherBlackboard.SetVariableValue("speed", currentSpeed);
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}