using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RepairAT : ActionTask {

        public BBParameter<float> arrivalDistance;
        public LayerMask targetMask;
		public float repairValue;
		public BBParameter<float> repairSpeed;
		public Blackboard lightHouseBlackboard;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			repairValue = 0;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (repairValue == 0f)
			{
				Collider[] objectsInRange = Physics.OverlapSphere(agent.transform.position, arrivalDistance.value, targetMask);
				if (objectsInRange.Length > 0)
				{
					foreach (Collider objectInRange in objectsInRange)
					{
						lightHouseBlackboard = objectInRange.GetComponentInParent<Blackboard>();

						if (lightHouseBlackboard == null)
						{
							Debug.LogError("Failed to get the lighthouse blackboard variable, cry now");
							continue;
						}
						repairValue = lightHouseBlackboard.GetVariableValue<float>("repairValue");
						Debug.Log(repairValue);
						break;
					}
				}
			}
			repairValue += repairSpeed.value * Time.deltaTime;
			if (repairValue > lightHouseBlackboard.GetVariableValue<float>("activeThreshold"))
			{
				lightHouseBlackboard.SetVariableValue("repairValue", lightHouseBlackboard.GetVariableValue<float>("activeThreshold"));
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