using UnityEngine;
using System.Collections;

public class EndGUI : MonoBehaviour {
		
	void  OnGUI (){
		if(Frogger.points > 0){
			Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
			GUI.Label ( new Rect(screenCenter.x-2,screenCenter.y+100,screenCenter.x+2,screenCenter.y+14), "GAME OVER! Score: " + Frogger.points);
		}
	}
}