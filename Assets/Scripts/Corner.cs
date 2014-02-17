using UnityEngine;
using System.Collections;

public class Corner : MonoBehaviour
{

		public GameObject manager;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnTriggerStay ()
		{
				manager.GetComponent<Manager> ().IncrementScore ();

				
		}
}
