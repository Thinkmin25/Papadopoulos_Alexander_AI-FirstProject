using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SwimAnimAT : ActionTask {

        public Transform[] joints = new Transform[5];
        Vector3 jointMovement = Vector3.zero;
        Vector3 tailMovement = Vector3.zero;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            var tempArray = agent.GetComponentsInChildren<Transform>();

            int arrayCount = 0;
            foreach (var joint in tempArray)
            {
                if (joint.gameObject.tag == "Joint")
                {
                    joints[arrayCount] = joint;
                    arrayCount++;
                    if (joint.gameObject.tag == "Tail")
                    {
                        joints[4] = joint;
                        
                    }
                    if (arrayCount == 4 && joints[4])
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
            foreach (var joint in joints)
            {
                joint.eulerAngles = Vector3.zero;
            }
		}

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {
            jointMovement.x = Mathf.Sin(Time.fixedTime * 6) * 50 + 120;
            tailMovement.x = Mathf.Sin(Time.fixedTime * 8) * 10;

            for (int i = 0; i < joints.Length; i++)
            {
                if (i >= 4)
                {
                    joints[i].eulerAngles = tailMovement;
                }
                else if (i >= 2)
                {
                    joints[i].eulerAngles = jointMovement;
                }
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