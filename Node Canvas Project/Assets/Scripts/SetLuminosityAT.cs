using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SetLuminosityAT : ActionTask {
		public BBParameter<Light> pointLight;
		public BBParameter<float> repairValue;
		public BBParameter<float> decayRate;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			pointLight.value.intensity = repairValue.value;
			repairValue.value -= decayRate.value * Time.deltaTime;
			if (repairValue.value < 0)
			{
				repairValue.value = 0;
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