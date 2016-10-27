#pragma strict
// http://answers.unity3d.com/questions/14290/switching-between-cameras.html

var Camera1 : Camera;
var Camera2 : Camera;

function Start(){
    Camera1.enabled = true;
    Camera2.enabled = false;

}

function Update () {
	if(Input.GetKey("1")){
  		Debug.Log("Using Camera One");
  		activateCameraOne();
 	}
 
 	if(Input.GetKey("2")){
  		Debug.Log("Using Camera Two");
  		activateCameraTwo();
 	}
}

function activateCameraOne () {
        Camera1.enabled = false;
        Camera2.enabled = true;
}

function activateCameraTwo () {
        Camera1.enabled = true;
        Camera2.enabled = false;
}



 
