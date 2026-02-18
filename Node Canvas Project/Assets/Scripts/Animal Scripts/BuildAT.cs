using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class BuildAT : ActionTask {

		public BBParameter<float> woodInventory;
		float buildWood = 0;
		float buildMult = 2;

		public BBParameter<GameObject> damGO;
		public DamManager damManager;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			if (damManager == null)
			{
				damManager = damGO.value.GetComponent<DamManager>();
			}
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			buildWood = Time.deltaTime * buildMult;
			if (woodInventory.value - buildWood < 0)
			{
				buildWood -= woodInventory.value;
				woodInventory.SetValue(0);
			}
			else
			{
				woodInventory.SetValue(woodInventory.value - buildWood);
			}

			damManager.damBuildValue += buildWood;

			if (woodInventory.value < 0)
			{
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