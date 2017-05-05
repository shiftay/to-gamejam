using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource efxSource;					//Drag a reference to the audio source which will play the sound effects.
	public AudioSource musicSource;					//Drag a reference to the audio source which will play the music.
	public static SoundManager instance = null;	//Allows other scripts to call functions from SoundManager.
	public float lowPitchRange = .95f;				//The lowest a sound effect will be randomly pitched.
	public float highrPitchRange = 1.05f;			//The highest a sound effect will be  randomly pitched.

	void Awake() {
		//Check if there is already an instance of SoundManager
		if (instance == null)
		{
			//if not, set it to this
			instance = this;
		}
		//If instance already exists
		else if (instance != this)
		{
			//Destroy tis, this enforces our singleton pattern so there can be one instance of SoundManager
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestoryOnLoad so that it won't be Destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
	}

	//Used to play single sound clips
	public void PlatSingle(AudioClip clip) {
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		efxSource.clip = clip;

		//play the clip
		efxSource.Play ();

	}

	//RandomizeSfx chooses randomly between various audio clip and slightly changes their pitch.
	public void RandomizeSfx(params AudioClip[] clips) {
		//Generate a random number between 0 and the length of our array of clips passed in.
		int randomIndex = Random.Range(0, clips.Length);

		//Chose a random pitch to play back our clip at between our high and low pitch ramges.
		float randomPitch = Random.Range(lowPitchRange, highrPitchRange);

		//set the pitch of the audio source to the randomly choosen pitch.
		efxSource.pitch = randomPitch;

		//set the clip to the clip at our randomly choosen index.
		efxSource.clip = clips[randomIndex];

		//Play the clip.
		efxSource.Play();
	}
}
