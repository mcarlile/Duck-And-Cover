using UnityEngine;
using System.Collections;

public class Chair : MonoBehaviour
{
		public int chairPosition;
		public GameObject manager;
		public bool chairsActive = true;

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
				if (chairsActive == true) {
						manager.GetComponent<Manager> ().SatInChair (chairPosition);

				}

		}

		public void Deactivate ()
		{
				chairsActive = false;
		}
}
