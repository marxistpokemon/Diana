using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class SoundPlayer : MonoBehaviour {

	public float sfxVolume = 1f;
	public float musicVolume = 1f;
	
	void Start () {
		MessageKit<PlayerAction>.addObserver(MsgType.PlayerAction, PlayPlayerSFX);
	}

	void PlayPlayerSFX (PlayerAction action) {
		audio.PlayOneShot(Resources.Load<AudioClip>(action.ToString()), sfxVolume);
	}
}
