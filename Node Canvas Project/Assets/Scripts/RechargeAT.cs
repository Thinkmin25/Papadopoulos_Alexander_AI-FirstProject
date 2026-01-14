using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;


namespace NodeCanvas.Tasks.Actions {

	public class RechargeAT : ActionTask {

        public Transform targetTransform;
        Blackboard agentBlackboard;
        public float speed;
        public float currentCharge;
		public float chargeSpeed;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            agentBlackboard = agent.GetComponent<Blackboard>();
            speed = agentBlackboard.GetVariableValue<float>("speed");
            

			// Represent the amount of time required to reach full charge from empty
            // MAKE IT WORK WITHA NOTHER SCRIPT pwetty pwease tysm
			chargeSpeed = 6;

            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            currentCharge = agentBlackboard.GetVariableValue<float>("currentCharge");
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            Vector3 directionToMove = (targetTransform.position - agent.transform.position).normalized;

            if (Vector3.Distance(agent.transform.position, targetTransform.position) > 0.1)
            {
                agent.transform.position += directionToMove * speed * Time.deltaTime;
            }
            else
            {
                currentCharge += Time.deltaTime * (100 / chargeSpeed);
                agentBlackboard.SetVariableValue("currentCharge", currentCharge);
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