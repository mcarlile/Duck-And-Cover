using UnityEngine;
using System.Collections;

public class FilmScreen : MonoBehaviour
{

		// Use this for initialization
		public MovieTexture movTexture;
		//	public TextMesh text;
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Space)) {

				}
		}

		public void StartVideo ()
		{
				renderer.material.mainTexture = movTexture;
				movTexture.Play ();
				audio.Play ();
		}
}
