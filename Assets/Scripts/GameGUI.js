function OnGUI () {
		GUI.Box (Rect (5,5,140,75), "Frogger");
		GUI.Box (Rect (5,30,140,20), "lives: " + Frogger.lives);
		GUI.Box (Rect (5,55,140,20), "points: " + Frogger.points);

}