using UnityEngine;
using System.Collections;

public class IntroManager2 : MonoBehaviour
{

		public float time;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				time += Time.deltaTime;

				if (time >= 1.0) {
						Debug.Log ("loadlevel should have happened");
						Application.LoadLevel (2);
				}
		}
}
