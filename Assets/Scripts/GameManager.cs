using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

	public int lives = 3;
	public int points = 0;

	// Use this for initialization
	void Start () {
	// Should we put lifes count as a global variable ?
	}

	void  Update (){
		// Should we reset the lifes count here ? I am not sure
	}		

	void  OnGUI (){
		GUI.Box ( new Rect(5,5,140,75), "Frogger");
		GUI.Box ( new Rect(5,30,140,20), "lives: " + lives);
		GUI.Box ( new Rect(5,55,140,20), "points: " + points);

		if(points > 0){
			Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
			GUI.Label ( new Rect(screenCenter.x-2,screenCenter.y+100,screenCenter.x+2,screenCenter.y+14), "GAME OVER! Score: " + points);
		}
	}

	public string LevelName= "Game";

	void  OnMouseDown (){
		Application.LoadLevel(LevelName);
	}

}
