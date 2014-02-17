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
		public float secondaryTime;
		public float tertiaryTime;
		public int chairOccupied;
		public GameObject bomb;
		public GameObject bombSounds;
		public GameObject emergencyLight;
		public bool timerOn = false;
		public GameObject instructions1;
		public GameObject instructions2;
		public GameObject instructions3;
		public GameObject instructions4;
		public GameObject instructions5;
		public GameObject instructions6;
		public GameObject instructions7;
		public GameObject instructions10;
		public GameObject instructions11;
		public GameObject instructionsSitSuccess;
		public GameObject instructionsSitFailure;

		public GameObject desk1;
		public GameObject desk2;
		public GameObject desk3;
		public GameObject desk4;
		public GameObject chair1;
		public GameObject chair2;
		public GameObject chair3;
		public GameObject chair4;
		public GameObject filmScreen;
		public bool showInstruction1 = true;
		public bool showInstruction2 = true;
		public bool allowSecondaryTimer = true;
		public bool allowTertiaryTimer = false;


		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (allowSecondaryTimer == true) {
						secondaryTime = secondaryTime += Time.deltaTime;
				}

				if (allowTertiaryTimer == true) {
						tertiaryTime = tertiaryTime += Time.deltaTime;
				}

				if (showInstruction2 == false) {
						HideInstruction2 ();
				}
				if ((secondaryTime >= 2.0) && (showInstruction1 == true)) {
						ShowInstruction1 ();
				}

				if ((secondaryTime >= 5.0) && (showInstruction2 == true)) {
						HideInstruction1 ();
						ShowInstruction2 ();
				} else {
						HideInstruction2 ();
				}

				if (secondaryTime >= 6.0) {
						ActivateChairs ();
						allowSecondaryTimer = false;
				}

				if (tertiaryTime >= 4.0) {
						instructions3.SetActive (true);
						instructionsSitFailure.SetActive (false);
						instructionsSitSuccess.SetActive (false);
				}

				if (tertiaryTime >= 6.0) {
						instructions4.SetActive (true);
						instructions3.SetActive (false);
						instructionsSitFailure.SetActive (false);
						instructionsSitSuccess.SetActive (false);
				}

				if (tertiaryTime >= 9.0) {
						instructions5.SetActive (true);
						instructions4.SetActive (false);
						instructions3.SetActive (false);
						instructionsSitFailure.SetActive (false);
						instructionsSitSuccess.SetActive (false);
				}

				if (tertiaryTime >= 12.0) {
						instructions6.SetActive (true);
						instructions5.SetActive (false);
						instructions4.SetActive (false);
						instructions3.SetActive (false);
						instructionsSitFailure.SetActive (false);
						instructionsSitSuccess.SetActive (false);
				}

				if (tertiaryTime >= 16.0) {
						instructions7.SetActive (true);
						instructions6.SetActive (false);
						instructions5.SetActive (false);
						instructions4.SetActive (false);
						instructions3.SetActive (false);
						instructionsSitFailure.SetActive (false);
						instructionsSitSuccess.SetActive (false);
				}

				if (tertiaryTime >= 16.0) {
						SatInChair ();
						instructions7.SetActive (false);
						instructions6.SetActive (false);
						instructions5.SetActive (false);
						instructions4.SetActive (false);
						instructions3.SetActive (false);
						instructionsSitFailure.SetActive (false);
						instructionsSitSuccess.SetActive (false);
				}



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
						instructions3.SetActive (false);
						instructionsSitSuccess.SetActive (false);
						instructionsSitFailure.SetActive (true);
						instructions2.SetActive (false);
						instructions3.SetActive (false);
						instructions4.SetActive (false);
						instructions5.SetActive (false);
						instructions6.SetActive (false);
						instructions7.SetActive (false);
						showInstruction1 = false;
						showInstruction2 = false;
						instructions10.SetActive (true);
				}

				if (time >= 108) {
						instructions3.SetActive (false);
						instructionsSitSuccess.SetActive (false);
						instructionsSitFailure.SetActive (true);
						instructions1.SetActive (false);
						instructions2.SetActive (false);
						instructions3.SetActive (false);
						instructions4.SetActive (false);
						instructions5.SetActive (false);
						instructions6.SetActive (false);
						instructions7.SetActive (false);
						showInstruction1 = false;
						showInstruction2 = false;
						instructions11.SetActive (true);
				}

				if (time >= 120) {
						bomb.SetActive (true);
				}
		
		}

		public void IncrementScore ()
		{
				score = score += Time.deltaTime;
		}



		public void SatInChair ()
		{
				filmScreen.GetComponent<FilmScreen> ().StartVideo ();
				StartVideoSequence ();
				mainCamera.enabled = false;
				directionalLight.light.intensity = lightDimLevel;
				projector.gameObject.SetActive (true);
				if (chairOccupied == 1) {
						roomCamera1.enabled = true;
						roomCamera2.enabled = false;
						roomCamera3.enabled = false;
						roomCamera4.enabled = false;
				}
				if (chairOccupied == 2) {
						roomCamera1.enabled = false;
						roomCamera2.enabled = true;
						roomCamera3.enabled = false;
						roomCamera4.enabled = false;
				}
				if (chairOccupied == 3) {
						roomCamera1.enabled = false;
						roomCamera2.enabled = false;
						roomCamera3.enabled = true;
						roomCamera4.enabled = false;

				}
	
				if (chairOccupied == 4) {
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

		public void ActivateChairs ()
		{
				chair1.SetActive (true);
				chair2.SetActive (true);
				chair3.SetActive (true);
				chair4.SetActive (true);
		}

		public void TriggerChairs ()
		{
				chair1.GetComponent<Chair> ().Activate ();
				chair2.GetComponent<Chair> ().Activate ();
				chair3.GetComponent<Chair> ().Activate ();
				chair4.GetComponent<Chair> ().Activate ();
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

		public void ClearMessages ()
		{
				Debug.Log ("Messages cleared");
				instructions1.SetActive (false);
				instructions2.SetActive (false);
				instructions3.SetActive (false);
				instructions10.SetActive (false);
		}

		public void ShowSitSuccess ()
		{
				instructionsSitSuccess.SetActive (true);
				instructionsSitFailure.SetActive (false);
				instructions1.SetActive (false);
				instructions2.SetActive (false);
				instructions3.SetActive (false);
				instructions10.SetActive (false);
				showInstruction1 = false;
				showInstruction2 = false;
		}

		public void ShowSitFailure ()
		{
				instructionsSitSuccess.SetActive (false);
				instructionsSitFailure.SetActive (true);
				instructions1.SetActive (false);
				instructions2.SetActive (false);
				instructions3.SetActive (false);
				instructions4.SetActive (false);
				instructions5.SetActive (false);
				instructions6.SetActive (false);
				instructions7.SetActive (false);
				instructions10.SetActive (false);
				showInstruction1 = false;
				showInstruction2 = false;
		}

		public void ShowInstruction1 ()
		{
				instructions1.SetActive (true);
		}

		public void HideInstruction1 ()
		{
				instructions1.SetActive (false);
		}

		public void ShowInstruction2 ()
		{
				instructions2.SetActive (true);
		}

		public void HideInstruction2 ()
		{
				instructions2.SetActive (false);
		}

		public void AllowTertiaryTimer (int occupiedChair)
		{
				chairOccupied = occupiedChair;
				allowTertiaryTimer = true;
		}

		public void DisableTertiaryTimer ()
		{
				allowTertiaryTimer = false;
				tertiaryTime = 0.0f;
		}
}
