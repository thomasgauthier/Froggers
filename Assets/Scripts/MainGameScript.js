public var car : GameObject;
public var CarSpawnDelay : float;

var readynow : boolean = true;
// http://www.unity3dstudent.com/2010/09/beginner-b22-pausing-scripts-with-waitforseconds/

function Update () {
	if(readynow){
  		CreateCars();
  	} 
}

function CreateCars() {
	
	readynow=false;
	
	// create a new car
	var track = Random.Range(0,-4);
	Debug.Log(track);
	var car = Instantiate(car,Vector3(8,2,(track*4)), Quaternion.identity);
   
   	// create timer delay
	var waitTime : float = Random.Range(0.1,CarSpawnDelay);
	yield WaitForSeconds(waitTime);
	
	readynow=true;
}