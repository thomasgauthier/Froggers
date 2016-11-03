using UnityEngine;
using System.Collections;

public class FroggerFPS : MonoBehaviour {
	public float speed = 3.0f;
	public GameObject blood;
	public string upKey = "up"; 
	public string downKey = "down"; 
	public string leftKey = "left"; 
	public string rightKey = "right"; 
	public string jumpKey = "m"; 

	private Vector3 startPos;
	private Transform child; 
	public Renderer TurnRed;

	void  Start (){

		startPos = transform.position;
		child = transform.Find("frogger"); 

	}

	void  Update (){


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
			if(readynow){
				StartCoroutine(froggerHit());
			}
		}


		if(other.gameObject.tag == "Turtle"){

			//transform.parent = other.transform;
			gameObject.GetComponent<MoveMe>().speed = other.transform.GetComponent<MoveMe>().speed;


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


		StartCoroutine (Fade ());



		yield return new WaitForSeconds(1f);


		Color color = TurnRed.material.GetColor ("_Color");
		color.a = 0;
		TurnRed.material.SetColor ("_Color", color);

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


		readynow=true;
	}


	IEnumerator Fade() {

		for (float f = 0; f <= 1; f += 0.1f) {

			Color color = TurnRed.material.GetColor ("_Color");
			color.a = f;
			TurnRed.material.SetColor ("_Color", color);
			yield return new WaitForSeconds(.01f);

		}

		Color color2 = TurnRed.material.GetColor ("_Color");
		color2.a = 1;
		TurnRed.material.SetColor ("_Color", color2);
	}
}