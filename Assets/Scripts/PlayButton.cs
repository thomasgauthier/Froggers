
using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {
	public FIXME_VAR_TYPE LevelName="Game";

	void  OnMouseDown (){
		Application.LoadLevel(LevelName);
	}

}