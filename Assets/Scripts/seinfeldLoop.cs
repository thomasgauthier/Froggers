using UnityEngine;
using System.Collections;

public class seinfeldLoop : MonoBehaviour {

	public AudioSource seinfeld;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		controlSound ();

	}

	void controlSound() {
		
		if (Input.GetKey (KeyCode.UpArrow)) {
			seinfeld.UnPause ();
		} 
		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			seinfeld.UnPause ();
		} 
		else if (Input.GetKey (KeyCode.LeftArrow)) {
			seinfeld.UnPause ();
		} 
		else if (Input.GetKey (KeyCode.RightArrow)) {
			seinfeld.UnPause ();
		} 
		else {
			seinfeld.Pause ();
		}
	}
		
}
