using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour
{

		public GameObject room;
		public GameObject floor;
		public GameObject gameOver;
		public bool startTimer = false;
		public bool showGameOver = false;
		public float time;
		public float waitTime;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (startTimer == true) {
						time += Time.deltaTime;
				}
				if (time >= waitTime) {
						gameOver.SetActive (true);
				}
		}

		void OnTriggerEnter (Collider otherCollider)
		{
				if (otherCollider.name.Contains ("Bomb")) {
						Debug.Log ("Oncollision enter happen");
						room.SetActive (false);
						floor.gameObject.GetComponent<MeshRenderer> ().active = false;
						StartTimer ();
				}
		}

		void StartTimer ()
		{
				startTimer = true;
		}

		IEnumerator Wait ()
		{
				yield return new WaitForSeconds (waitTime);
				showGameOver = true;

		}
}