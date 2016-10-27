var worldWidth : float;
private var resetPos : Vector3;

function Start () {
	resetPos = transform.position;	
}

function Update () {

	/* Warp Zone */
	if(transform.position.x > worldWidth) transform.position.x = -worldWidth;
	if(transform.position.x < -worldWidth) transform.position.x = worldWidth;
	
	/* Reset Position */
	if(transform.position.y < -5) transform.position = resetPos;
}