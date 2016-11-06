using UnityEngine;
using System.Collections;

public class seinfeldLoop : MonoBehaviour {

	CharacterController player;

	// Use this for initialization
	void Start () {
		player = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.velocity.magnitude > 1) {
			GetComponent<AudioSource> ().UnPause ();
		} else {
			GetComponent<AudioSource> ().Pause ();
		}
	}
}
