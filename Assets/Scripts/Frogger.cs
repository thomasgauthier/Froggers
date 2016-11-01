using UnityEngine;
using System.Collections;

public class Frogger : MonoBehaviour {
	static int lives = 3;
	static int points = 0;
	public float speed = 3.0f;
	public GameObject blood;
	public string upKey = "up"; 
	public string downKey = "down"; 
	public string leftKey = "left"; 
	public string rightKey = "right"; 
	public string jumpKey = "m"; 

	private Vector3 startPos;
	private Transform child; 

	void  Start (){

		startPos = transform.position;
		child = transform.Find("frogger"); 

	}

	void  Update (){

		float translationZ;
		float translationY;   
		float translationX;   


		if (Input.GetKeyDown(upKey)){

			// calculate Z translation
			// deltaTime: time in seconds to complete the last frame
			//translationZ = 1 * speed * Time.deltaTime;
			// Play child animation
			child.GetComponent.<Animation>().CrossFade("Jump");
			gameObject.GetComponent<MoveMe>().speed = 0;
			transform.Translate(0,0,2.5ff);

		}else if (Input.GetKeyDown(downKey)){

			// calculate Z translation 
			//translationZ = -1 * speed * Time.deltaTime;;
			// Play child animation
			child.GetComponent.<Animation>().CrossFade("Jump"); 
			gameObject.GetComponent<MoveMe>().speed = 0;
			transform.Translate(0,0,-2.5ff);

		} else {

			// reset translation Z speed
			translationZ = 0; 
			child.GetComponent.<Animation>().CrossFade("Stop");

		}

		if(Input.GetKeyDown(jumpKey)){
			// calculate Y translation
			//translationY = speed * Time.deltaTime;
		}else{
			translationY = 0;
		}


		// Rotate frogger 90 degrees left or right
		if(Input.GetKeyDown(rightKey)){

			// right
			//transform.eulerAngles.y += 90; 
			//translationX = 1 * speed * Time.deltaTime;
			transform.Translate(2.5ff,0,0);



		} else if(Input.GetKeyDown(leftKey)){

			// left
			//translationX = -1 * speed * Time.deltaTime;
			transform.Translate(-2.5ff,0,0);
		}

		// Translate frogger according the Y and Z translation variable
		//transform.Translate(translationX,translationY,translationZ);

	}

	private bool  readynow = true;

	void  OnTriggerEnter ( Collider other  ){
		if(other.gameObject.tag == "Car"){

			Instantiate(blood,Vector3(transform.position.x,0.05f,transform.position.z), Quaternion.identity);
			if(readynow){
				froggerHit();
			}

		} 

		if(other.gameObject.tag == "Water") {
			if(readynow){
				froggerHit();
			}
		}


		if(other.gameObject.tag == "Turtle"){

			//transform.parent = other.transform;
			gameObject.GetComponent<MoveMe>().speed = other.transform.GetComponent<"MoveMe">().speed;


		} 

		if(other.gameObject.tag == "Point"){
			print("Extra Live");
			lives++;
			points += 100;
			Destroy (other.gameObject);
		}
	}


	void  froggerHit (){

		readynow=false;

		child.GetComponent.<Renderer>().enabled = false;
		yield return new WaitForSeconds(1);

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
}