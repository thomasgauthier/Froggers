static var lives : int = 3;
static var points : int = 0;
public var speed : float = 3.0;
public var blood : GameObject;
public var upKey : String = "up"; 
public var downKey : String = "down"; 
public var leftKey : String = "left"; 
public var rightKey : String = "right"; 
public var jumpKey : String = "m"; 

private var startPos : Vector3;
private var child : Transform; 

function Start () {

	startPos = transform.position;
	child = transform.Find("frogger"); 

}

function Update () {
    
	var translationZ : float;
	var translationY : float;   
	var translationX : float;   

   	   	   
   	if (Input.GetKey(upKey)){
   		
   		// calculate Z translation
   		// deltaTime: time in seconds to complete the last frame
   		translationZ = 1 * speed * Time.deltaTime;
   		// Play child animation
    	child.GetComponent.<Animation>().CrossFade("Jump");
   	
   	}else if (Input.GetKey(downKey)){
   		
   		// calculate Z translation 
   		translationZ = -1 * speed * Time.deltaTime;;
   		// Play child animation
    	child.GetComponent.<Animation>().CrossFade("Jump"); 
    
    } else {
    
    	// reset translation Z speed
   		translationZ = 0; 
   		child.GetComponent.<Animation>().CrossFade("Stop");
   	
   	}
   	
	if(Input.GetKey(jumpKey)){
		// calculate Y translation
		translationY = speed * Time.deltaTime;
	}else{
		translationY = 0;
	}

    
    // Rotate frogger 90 degrees left or right
	if(Input.GetKey(rightKey)){
		
		// right
	    //transform.eulerAngles.y += 90; 
	    translationX = 1 * speed * Time.deltaTime;

    
    } else if(Input.GetKey(leftKey)){
	    
	    // left
        translationX = -1 * speed * Time.deltaTime;
    	
    }
        	
    // Translate frogger according the Y and Z translation variable
	transform.Translate(translationX,translationY,translationZ);
    
}

private var readynow : boolean = true;

function OnTriggerEnter (other : Collider) {
	if(other.gameObject.tag == "Car"){
		
		Instantiate(blood,Vector3(transform.position.x,0.05,transform.position.z), Quaternion.identity);
		if(readynow){
			froggerHit();
		}
	
	} 
	
	if(other.gameObject.tag == "Water") {
		if(readynow){
			froggerHit();
		}
	}
	
	if(other.gameObject.tag == "Point"){
		print("Extra Live");
		lives++;
		points += 100;
		Destroy (other.gameObject);
	}
}

function froggerHit () {

 	readynow=false;
	
	child.GetComponent.<Renderer>().enabled = false;
	yield WaitForSeconds(1);
	
	// check if frogger respawns or dies
	if(lives>0){
		transform.position = startPos; 		
		lives--;
		print("Hit by a car! Froggers lives: "+lives);	
	}else{
		Destroy (gameObject);
		Debug.Log("GAME OVER");
		Application.LoadLevel ("Start");
	}
 			
 	child.GetComponent.<Renderer>().enabled = true;
	
	readynow=true;
}