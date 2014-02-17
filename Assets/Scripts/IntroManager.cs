using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour
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

				if (time >= 3.0) {
						Debug.Log ("loadlevel should have happened");
						Application.LoadLevel (1);
				}
		}
}
