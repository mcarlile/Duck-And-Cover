using UnityEngine;
using System.Collections;

public class Chair : MonoBehaviour
{
		public int chairPosition;
		public GameObject manager;
		public bool chairsActive = false;
		public GameObject instructionsSitSuccess;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnTriggerEnter ()
		{
				if (chairsActive == false) {
						manager.GetComponent<Manager> ().ShowSitSuccess ();
				}

				if (chairsActive == true) {
						manager.GetComponent<Manager> ().SatInChair (chairPosition);

				}

		}

		void OnTriggerExit ()
		{
				if (chairsActive == false) {
						manager.GetComponent<Manager> ().ShowSitFailure ();
				}
		
				if (chairsActive == true) {
						manager.GetComponent<Manager> ().SatInChair (chairPosition);
			
				}
		
		}

		public void Deactivate ()
		{
				chairsActive = false;
		}

		public void Activate ()
		{
				chairsActive = true;
		}

		public void AllowSitting ()
		{
//			gameObject.GetComponent<BoxCollider>().isTrigger (true)
		}
}
