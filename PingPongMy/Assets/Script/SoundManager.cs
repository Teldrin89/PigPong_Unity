using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	// Used to store all sound effects

	public static SoundManager Instance = null;

	public AudioClip GoalBloop;
	public AudioClip HitPaddleBloop;
	public AudioClip LossBuzz;
	public AudioClip WallBloop;
	public AudioClip WinSound;


	private AudioSource soundEffectAudio;


	// Use this for initialization
	void Start () {
		if (Instance == null) 
		{
			Instance = this;
		} else if (Instance != this) 
		{
			Destroy (gameObject);
		}

		AudioSource[] sources = GetComponents<AudioSource> ();

		foreach (AudioSource source in sources) 
		{
			if (source.clip == null) 
			{
				soundEffectAudio = source;
			}
		}

	}

	// Function to allow any object to call sound manager to obtain sound

	public void PlayOneShot(AudioClip clip)
	{
		soundEffectAudio.PlayOneShot (clip);
	}


	// Update is called once per frame
	void Update () {
		
	}
}
