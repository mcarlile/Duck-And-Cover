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
						manager.GetComponent<Manager> ().AllowTertiaryTimer (chairPosition);
				}

				if (chairsActive == true) {
				}

		}

		void OnTriggerExit ()
		{
				if (chairsActive == false) {
						manager.GetComponent<Manager> ().ShowSitFailure ();
						manager.GetComponent<Manager> ().DisableTertiaryTimer ();

				}
		
				if (chairsActive == true) {
						//manager.GetComponent<Manager> ().SatInChair (chairPosition);
			
				}
		
		}

		public void Deactivate ()
		{
				chairsActive = false;
		}

		public void Activate ()
		{
				Debug.Log ("chairs are active");
				chairsActive = true;
		}

		public void AllowSitting ()
		{
//			gameObject.GetComponent<BoxCollider>().isTrigger (true)
		}
}
