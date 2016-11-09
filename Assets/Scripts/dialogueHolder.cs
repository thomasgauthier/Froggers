using UnityEngine;
using System.Collections;

public class dialogueHolder : MonoBehaviour {

	public string dialogue; 
	private dialogueManager dMan; 

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<dialogueManager> ();
		Invoke ("displayTextPlease", 5f); 
	}
	
	// Update is called once per frame
	void Update () {
		 
		  

	}
	//make the text box appear
	void displayTextPlease() {
		
		dMan.ShowBox (dialogue);

	}
}
