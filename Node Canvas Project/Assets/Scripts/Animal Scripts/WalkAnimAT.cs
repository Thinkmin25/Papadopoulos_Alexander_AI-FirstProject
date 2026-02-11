using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class WalkAT : ActionTask {

		public Transform[] joints = new Transform[4];
		Vector3 jointMovement = Vector3.zero;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			var tempArray = agent.GetComponentsInChildren<Transform>();

			int arrayCount = 0;
			foreach (var joint in tempArray)
			{
				if (joint.gameObject.tag == "Joint")
				{
					joints[arrayCount] = joint;
					arrayCount++;
					if (arrayCount == 4)
					{
						break;
					}
				}
			}
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			jointMovement.x = Mathf.Sin(Time.fixedTime * 4) * 25;

            for (int i = 0; i < joints.Length; i++)
			{
				if (i % 2 == 0)
				{
					joints[i].eulerAngles = jointMovement;
				}
				else joints[i].eulerAngles = -jointMovement;
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