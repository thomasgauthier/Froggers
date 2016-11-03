using UnityEngine;
using System.Collections;

public class Frogger : MonoBehaviour {

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
			// Play child animation
			transform.Translate(0,0,2.5f);

		}else if (Input.GetKeyDown(downKey)){

			// calculate Z translation 
			// Play child animation
			transform.Translate(0,0,-2.5f);
		} else {
			// reset translation Z speed
			translationZ = 0; 
		}

		if(Input.GetKeyDown(jumpKey)){
			// calculate Y translation
		}else{
			translationY = 0;
		}


		// Rotate frogger 90 degrees left or right
		if(Input.GetKeyDown(rightKey)){
			// right
			transform.Translate(2.5f,0,0);



		} else if(Input.GetKeyDown(leftKey)){
			// left
			transform.Translate(-2.5f,0,0);
		}
			

	}

	private bool  readynow = true;

	void  OnTriggerEnter ( Collider other  ){
		if(other.gameObject.tag == "Car"){

						Instantiate(blood, new Vector3(transform.position.x,0.55f,transform.position.z), Quaternion.identity);
			if(readynow){
				StartCoroutine(froggerHit());
			}

		} 

		if(other.gameObject.tag == "Water") {
			print (other);
			if(readynow){
				StartCoroutine(froggerHit());
			}
		}


		if(other.gameObject.tag == "Turtle"){

		} 

		if(other.gameObject.tag == "Point"){
			print("Extra Live");
			GameManager.Instance.lives++;
			GameManager.Instance.points += 100;
			Destroy (other.gameObject);
		}
	}


	IEnumerator  froggerHit (){

		readynow=false;

		child.GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(1);

		// check if frogger respawns or dies
		if(GameManager.Instance.lives>0){
			transform.position = startPos; 		
			GameManager.Instance.lives--;
			print("Hit by a car! Froggers lives: " + GameManager.Instance.lives);	
		}else{
			Destroy (gameObject);
			Debug.Log("GAME OVER");
			Application.LoadLevel ("Start");
		}

		child.GetComponent<Renderer>().enabled = true;

		readynow=true;
	}
}