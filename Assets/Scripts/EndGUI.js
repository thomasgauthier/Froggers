function OnGUI () {
	if(Frogger.points){
		var screenCenter = Vector2(Screen.width / 2, Screen.height / 2);
		GUI.Label (Rect (screenCenter.x-2,screenCenter.y+100,screenCenter.x+2,screenCenter.y+14), "GAME OVER! Score: " + Frogger.points);
	}
}