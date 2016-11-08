using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MinimalistFrogger : MonoBehaviour {
	 
	public GameObject winMessage; //a happy face
	private bool isShowing = false; //whether or not the happy face is showing
	public GameObject minimalFinish; //red box
	private bool youWin = false; //triggers win state
	public AudioSource winSound; 

	// Use this for initialization
	void Start () { 
		winMessage.SetActive (isShowing);//happy face is invisible
	}

	// Update is called once per frame
	void Update () {
		//move the green sqaure along Z when the Up key is pressed
		transform.Translate (0f, 0f, Input.GetAxis ("Vertical") * (Time.deltaTime * 2));

		//if winstate is achieved, display happy face, wait 3s, return to title
		if (youWin == true) {
			isShowing = true; 
			winMessage.SetActive (isShowing); 
			Invoke ("backToStart", 3); 
		}
	}//end update
		
	void OnTriggerEnter (Collider minimalFinish) {
		youWin = true;//trigger the win state
		winSound.Play (); 
	}

	void backToStart() {
		SceneManager.LoadScene (0);//return to level select screen
	}
		
}
