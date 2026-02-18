using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class NeedsManagerAT : ActionTask {

		public BBParameter<float> foodNeed;
		public BBParameter<float> foodDecay;


        public BBParameter<float> teethNeed;
		public BBParameter<float> teethDecay;


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
			foodNeed.value -= Time.deltaTime * foodDecay.value;
			if (foodNeed.value > 100)
			{
				foodNeed.value = 100;
			}
			foodNeed.SetValue(foodNeed.value);

            teethNeed.value -= Time.deltaTime * teethDecay.value;
            if (teethNeed.value > 100)
            {
                teethNeed.value = 100;
            }
            teethNeed.SetValue(teethNeed.value);
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}