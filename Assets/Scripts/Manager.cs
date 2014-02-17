using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{

		public float score;
		public TextMesh scoreMesh;
		public Camera mainCamera;
		public Camera roomCamera1;
		public Camera roomCamera2;
		public Camera roomCamera3;
		public Camera roomCamera4;
		public Light directionalLight;
		public Light projector;
		public float lightDimLevel;
		public float time;
		public GameObject bombSounds;
		public GameObject emergencyLight;
		public bool timerOn = false;
		public GameObject instructions1;
		public GameObject instructions2;
		public GameObject instructions3;
		public GameObject instructions4;
		public GameObject desk1;
		public GameObject desk2;
		public GameObject desk3;
		public GameObject desk4;
		public GameObject chair1;
		public GameObject chair2;
		public GameObject chair3;
		public GameObject chair4;
		public GameObject filmScreen;

		// Use this for initialization
		void Start ()
		{
				instructions1.SetActive (true);
		}
	
		// Update is called once per frame
		void Update ()
		{
				scoreMesh.GetComponent<TextMesh> ().text = "" + score;
				if (timerOn == (true)) {
						time = time += Time.deltaTime;
				}

				if (time >= 75) {
						bombSounds.SetActive (true);
				}

				if (time >= 102) {
						StartBombSequence ();
						mainCamera.enabled = true;
						roomCamera1.enabled = false;
						roomCamera2.enabled = false;
						roomCamera3.enabled = false;
						roomCamera4.enabled = false;
						DeactivateChairs ();
						ActivateDesks ();
				}

				if (time >= 104) {
						instructions1.SetActive (false);
						instructions3.SetActive (true);
				}

				if (time >= 108) {
						instructions3.SetActive (false);
						instructions4.SetActive (true);
				}

				if (time >= 120) {
						Application.LoadLevel (3);
				}
		
		}

		public void IncrementScore ()
		{
				score = score += Time.deltaTime;
		}



		public void SatInChair (int CameraToSwitchTo)
		{
				filmScreen.GetComponent<FilmScreen> ().StartVideo ();
				StartVideoSequence ();
				mainCamera.enabled = false;
				directionalLight.light.intensity = lightDimLevel;
				projector.gameObject.SetActive (true);
				if (CameraToSwitchTo == 1) {
						roomCamera1.enabled = true;
						roomCamera2.enabled = false;
						roomCamera3.enabled = false;
						roomCamera4.enabled = false;
				}
				if (CameraToSwitchTo == 2) {
						roomCamera1.enabled = false;
						roomCamera2.enabled = true;
						roomCamera3.enabled = false;
						roomCamera4.enabled = false;
				}
				if (CameraToSwitchTo == 3) {
						roomCamera1.enabled = false;
						roomCamera2.enabled = false;
						roomCamera3.enabled = true;
						roomCamera4.enabled = false;

				}
	
				if (CameraToSwitchTo == 4) {
						roomCamera1.enabled = false;
						roomCamera2.enabled = false;
						roomCamera3.enabled = false;
						roomCamera4.enabled = true;
				}
		}

		public void StartVideoSequence ()
		{
				timerOn = true;
		}
	
		public void StartBombSequence ()
		{
				Debug.Log ("Startbombsequencecalled");
				emergencyLight.SetActive (true);
				emergencyLight.GetComponent<EmergencyLight> ().ActivateEmergencyLight ();
		}

		public void DeactivateChairs ()
		{
				chair1.GetComponent<Chair> ().Deactivate ();
				chair2.GetComponent<Chair> ().Deactivate ();
				chair3.GetComponent<Chair> ().Deactivate ();
				chair4.GetComponent<Chair> ().Deactivate ();
		}

		public void ActivateDesks ()
		{
				desk1.GetComponent<Desk> ().Activate ();
				desk2.GetComponent<Desk> ().Activate ();
				desk3.GetComponent<Desk> ().Activate ();
				desk4.GetComponent<Desk> ().Activate ();



		}
}
