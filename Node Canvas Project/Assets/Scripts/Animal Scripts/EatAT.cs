using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class EatAT : ActionTask {

		public BBParameter<GameObject> targetGO;
		public BBParameter<float> foodValue;
		public BBParameter<float> foodThreshold;
		public BBParameter<float> teethValue;
		public BBParameter<float> woodValue;
		EdiblePlant epScript;

		float foodMult = 4;
		float woodMult = 4;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			if (targetGO.value.TryGetComponent(typeof(EdiblePlant), out var component))
			{
				epScript = (EdiblePlant)component;
			}
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (epScript.isTree)
			{
				if (foodValue.value < foodThreshold.value && teethValue.value > foodValue.value)
				{
					foodValue.SetValue(foodValue.value + Time.deltaTime * foodMult / 2);
				}
				else
				{
					teethValue.SetValue(teethValue.value + Time.deltaTime * woodMult);
					woodValue.SetValue(woodValue.value + Time.deltaTime * woodMult);
				}
			}
			else
			{
                foodValue.SetValue(foodValue.value + Time.deltaTime * foodMult);
            }

			epScript.resourceValue -= Time.deltaTime;
			if (epScript.resourceValue < 0 || foodValue.value > 100 || teethValue.value > 100)
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