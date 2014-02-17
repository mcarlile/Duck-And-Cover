using UnityEngine;
using System.Collections;

public class BombSounds : MonoBehaviour
{
		public AudioClip preBomb;
		public bool playAudio = false;
		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (playAudio = true) {
						audio.PlayOneShot (preBomb);

				}

		}

		public void StartBombSounds ()
		{
				Debug.Log ("StartBombSounds called");	
				playAudio = true;
		}

}
