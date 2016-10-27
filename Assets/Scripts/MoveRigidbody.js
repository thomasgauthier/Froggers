var speed : float;

function Update () {
	GetComponent.<Rigidbody>().velocity = Vector3(speed,0,0);
}