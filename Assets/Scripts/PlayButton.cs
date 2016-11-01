
using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {
	public string LevelName= "Game";

	void  OnMouseDown (){
		Application.LoadLevel(LevelName);
	}

}