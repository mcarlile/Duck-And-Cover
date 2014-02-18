using UnityEngine;
using System.Collections;

public class Desk : MonoBehaviour
{

		public GameObject instructionsDuckAndCoverFailure;
		public GameObject instructionsDuckAndCoverSuccess;
		public GameObject manager;
		public bool desksActive = false;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				Debug.Log ("desksActive: " + desksActive);
		}

		void OnTriggerEnter (Collider otherCollider)
		{
				if (otherCollider.name.Contains ("Sphere")) {
						if (desksActive == true) {
								manager.GetComponent<Manager> ().ShowSitSuccess ();
								instructionsDuckAndCoverFailure.SetActive (false);
								instructionsDuckAndCoverSuccess.SetActive (true);
						}
				}
		}

		void OnTriggerExit (Collider otherCollider)
		{
				if (otherCollider.name.Contains ("Sphere")) {
						if (desksActive == true) {
								manager.GetComponent<Manager> ().ShowSitFailure ();
								instructionsDuckAndCoverFailure.SetActive (true);
								instructionsDuckAndCoverSuccess.SetActive (false);
						}
				}
		}

		public void Activate ()
		{
				desksActive = true;
		}
}
