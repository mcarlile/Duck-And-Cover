using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour
{
		public bool safe = false;
		public GameObject room;
		public GameObject floor;
		public GameObject gameOver;
		public GameObject successText;
		public GameObject failText;

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
						if (safe == true) {
								successText.SetActive (true);
						} else {
								failText.SetActive (true);
						}
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

		public void SetSafetoTrue ()
		{
				Debug.Log ("setsafetotruehasbeencalled");
				safe = true;
		}

		public void SetSafetoFalse ()
		{
				Debug.Log ("setsafetofalsehasbeencalled");

				safe = false;
		}
}