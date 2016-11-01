using UnityEngine;
using System.Collections;

public class MYCLASSNAME : MonoBehaviour {
	void  OnGUI (){
		GUI.Box ( new Rect(5,5,140,75), "Frogger");
		GUI.Box ( new Rect(5,30,140,20), "lives: " + Frogger.lives);
		GUI.Box ( new Rect(5,55,140,20), "points: " + Frogger.points);

	}
}