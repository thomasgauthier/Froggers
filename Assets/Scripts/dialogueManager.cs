using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dialogueManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText; 

	public bool dialogueActive;

	public string[] dialogeLines;
	public int currentLine;

	// Use this for initialization
	void Start () {
		dBox.SetActive (false); 
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogueActive && Input.GetKeyDown(KeyCode.Space)) { 
			
			currentLine++;
		}

		if (currentLine >= dialogeLines.Length) {
			//when you run out of dialogue lines, close dBox, reset array, return to game select screen
			dBox.SetActive (false); 
			dialogueActive = false;

			currentLine = 0; 

			Invoke ("backToMenu", 5); 
		}

		dText.text = dialogeLines [currentLine]; //text displayed is the current line from the array 

	}//end update

	public void ShowBox(string dialogue) {

		dialogueActive = true;
		dBox.SetActive (true);
		dText.text = dialogue; 

	}

	void backToMenu() {
		SceneManager.LoadScene ("Start"); 
	}
}
