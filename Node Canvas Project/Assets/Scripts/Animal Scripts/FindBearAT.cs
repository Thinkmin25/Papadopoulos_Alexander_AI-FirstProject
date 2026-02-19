using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class FindBearAT : ActionTask {

		float findRange = 25;
		int bearMask = 1 << 12;
		public float bearScareMeter = 0;
		public float bearScareLimit = 3;
		public BBParameter<float> fearValue;
		public BBParameter<float> fearMax;

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
			if (Physics.CheckSphere(agent.transform.position + agent.transform.forward * findRange / 1.75f, findRange / 2, bearMask, QueryTriggerInteraction.UseGlobal))
			{
				bearScareMeter += Time.deltaTime;
				if (bearScareMeter > bearScareLimit)
				{
					fearValue.SetValue(fearMax.value + 1);
					bearScareMeter = 0;
				}
			}
			else
			{
				if (bearScareLimit <= 0)
				{
					bearScareLimit = 0;
				}
				else
				{
					bearScareLimit -= Time.deltaTime;
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