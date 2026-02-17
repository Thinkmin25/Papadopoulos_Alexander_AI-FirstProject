using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class IdleAnimAT : ActionTask {

        public Transform headTransform;
		float rotateX = 0;
		float rotateY = 0;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			
            var tempArray = agent.GetComponentsInChildren<Transform>();

            foreach (var joint in tempArray)
            {
                if (joint.gameObject.tag == "Head")
                {
                    headTransform = joint;
					Debug.Log("headed");
                    break;
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
            rotateX = Mathf.Sin(Time.fixedTime * 2.5f) * 10;
            rotateY = Mathf.Sin(Time.fixedTime * 1.25f) * 60;
            headTransform.eulerAngles = new Vector3(rotateX, rotateY, 0);
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}