using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;



namespace NodeCanvas.Tasks.Actions {

    //Moving towards a target
    public class ApproachAT : ActionTask {

		public Vector3 targetTransform;
		Blackboard agentBlackboard;
        public float speed;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
            agentBlackboard = agent.GetComponent<Blackboard>();
            targetTransform = new Vector3(Random.Range(-9, 9), agent.transform.position.y, Random.Range(-9, 9));
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            targetTransform = new Vector3(Random.Range(-9, 9), agent.transform.position.y, Random.Range(-9, 9));
            
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            // Move object towards the target transform
            speed = agentBlackboard.GetVariableValue<float>("speed");
            Vector3 directionToMove = (targetTransform - agent.transform.position).normalized;
            agent.transform.position += directionToMove * speed * Time.deltaTime;
            if (Vector3.Distance(agent.transform.position, targetTransform) < speed * Time.deltaTime)
            {
                targetTransform = new Vector3(Random.Range(-30, 30), agent.transform.position.y, Random.Range(-30, 30));
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