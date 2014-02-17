using UnityEngine;
using System.Collections;

public class Desk : MonoBehaviour
{

		public GameObject instructionsSafe;
		public GameObject instructionsDanger;
		public bool desksActive = false;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnTriggerEnter (Collider otherCollider)
		{
				if (otherCollider.name.Contains ("Sphere")) {
						if (desksActive == true) {
								instructionsDanger.SetActive (false);
								instructionsSafe.SetActive (true);
						}
				}
		}

		void OnTriggerExit (Collider otherCollider)
		{
				if (otherCollider.name.Contains ("Sphere")) {
						if (desksActive == true) {
								instructionsDanger.SetActive (true);
								instructionsSafe.SetActive (false);
						}
				}
		}

		public void Activate ()
		{
				desksActive = true;
		}
}
