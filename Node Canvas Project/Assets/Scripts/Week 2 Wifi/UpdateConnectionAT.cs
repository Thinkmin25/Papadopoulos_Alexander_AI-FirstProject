using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEditor.MemoryProfiler;


namespace NodeCanvas.Tasks.Actions {

	public class UpdateConnectionAT : ActionTask {

        public BBParameter<float> connection;
        public BBParameter<float> wifi;

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
            connection.value += (wifi.value / 2) - 0.5f;
            EndAction(connection.value > 10);
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}