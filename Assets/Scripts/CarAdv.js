public var EndOfWorld : float;
public var minDist : float;
private var speed : float;

function Start () {
	speed = Random.Range(0.5,2.0);
}

function Update () {
	
	if(transform.position.x > EndOfWorld) {
		// move to the left
		transform.Translate(Vector3.left * Time.deltaTime * speed);
		
	}else{
		// end of world
		Destroy (gameObject);
	}
	
	// http://www.unity3dstudent.com/2010/08/intermediate-i01-raycasting/
	// draw ray
	var right = transform.TransformDirection(Vector3.right);
   	var hit : RaycastHit;    
   	Debug.DrawRay(transform.position, -right * minDist, Color.green);
 
 	// check ray hit
   	if(Physics.Raycast(transform.position, -right, hit, minDist)){
      if(hit.collider.gameObject.tag == "Car"){
           
           // change speed to car speed infront
           var targetScript = hit.collider.gameObject.GetComponent("Car");
           speed = targetScript.getSpeed();
      }
   }
}

function getSpeed() {
	return speed;
}