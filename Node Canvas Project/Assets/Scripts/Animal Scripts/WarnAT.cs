using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class WarnAT : ActionTask {

		float warnRange = 10;
		int beaverMask = 1 << 3;
		float warnMult = 2;
		Transform tailTransform;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
            var tempArray = agent.GetComponentsInChildren<Transform>();
            foreach (var joint in tempArray)
            {
                if (joint.gameObject.tag == "Joint")
                {
                    if (joint.gameObject.name == "Tail Base")
                    {
                        tailTransform = joint;
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
			var beavers = Physics.SphereCastAll(agent.transform.position, warnRange, -agent.transform.forward, 0.1f, beaverMask, QueryTriggerInteraction.UseGlobal);
			if (beavers != null)
			{
				foreach (var beaver in beavers)
				{
					Blackboard beaverBB = beaver.collider.gameObject.GetComponent<Blackboard>();
					beaverBB.SetVariableValue("fearValue", beaverBB.GetVariableValue<float>("fearValue") + Time.deltaTime * warnMult);
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