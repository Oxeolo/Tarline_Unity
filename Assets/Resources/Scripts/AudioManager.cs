using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public static AudioClip Start_Sound;
	public static AudioClip	Gear_Sound;
	public static AudioClip Blank_Sound;
	public static AudioClip Weight_Sound;
	public static AudioClip Line_Sound;
	public static AudioClip Pylon_Sound;
	public static AudioClip Spike_Sound;
	public static AudioClip Bump_Sound;
	public static AudioClip Destruction_Sound;
	void Start () {
		Gear_Sound = Resources.Load ("Audio/Gear") as AudioClip;
		Start_Sound = Resources.Load ("Audio/Start") as AudioClip;
		Blank_Sound = Resources.Load ("Audio/Null") as AudioClip;
		Weight_Sound = Resources.Load ("Audio/Weight") as AudioClip;
		Line_Sound = Resources.Load ("Audio/Line") as AudioClip;
		Pylon_Sound = Resources.Load ("Audio/Pylon") as AudioClip;
		Spike_Sound = Resources.Load ("Audio/Spikes") as AudioClip;
		Bump_Sound = Resources.Load ("Audio/Bump") as AudioClip;
		Destruction_Sound = Resources.Load ("Audio/Destruction") as AudioClip;

	}
	

	void Update () {

	}

	public static void Play_Audio (AudioClip clip) {
		Camera.main.GetComponent<AudioSource> ().clip = clip;
		Camera.main.GetComponent<AudioSource> ().Play ();
	}

}






//Tyler's Work