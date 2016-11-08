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

	private float startColliderZ;

	private Vector3 startPos;
	private Transform child; 

	private Animator froggerAnimator;

	public GameObject rend;

	void Awake(){
		froggerAnimator = GetComponentInChildren<Animator> ();
	}

	void  Start (){
		startPos = transform.position;
		child = transform.Find("Avatar"); 

		startColliderZ = GetComponent<BoxCollider> ().center.z;
		print (startColliderZ);
	}

	void  Update (){


		Vector3 colCenter = GetComponent<BoxCollider> ().center;
		GetComponent<BoxCollider> ().center = new Vector3 (colCenter.x, colCenter.y, startColliderZ + child.transform.localPosition.z);

		float translationZ;
		float translationY;   
		float translationX;   


		if (froggerAnimator.GetCurrentAnimatorStateInfo (0).IsName ("frog_jump_anim") &&
			froggerAnimator.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1.0f) {

			Vector3 pos = transform.position;
			Vector3 childPos = froggerAnimator.gameObject.transform.localPosition;

			if (transform.rotation.eulerAngles.y == 0) {
				transform.position = new Vector3 (pos.x, pos.y, pos.z + childPos.z);
			} else if (transform.rotation.eulerAngles.y == 90) {
				transform.position = new Vector3 (pos.x + childPos.z, pos.y, pos.z);
			} else if (transform.rotation.eulerAngles.y == 180) {
				transform.position = new Vector3 (pos.x, pos.y, pos.z - childPos.z);
			} else if(transform.rotation.eulerAngles.y == 270){
				transform.position = new Vector3 (pos.x - childPos.z, pos.y, pos.z);
			}
				froggerAnimator.gameObject.transform.localPosition = new Vector3 (childPos.x, childPos.y, 0);

			froggerAnimator.SetTrigger ("idle");
			GetComponent<BoxCollider> ().center = new Vector3 (colCenter.x, colCenter.y, startColliderZ);

		}


		if (Input.GetKeyDown(upKey)){

			// calculate Z translation
			// deltaTime: time in seconds to complete the last frame
			// Play child animation
			//transform.Translate(0,0,2.5f);
			if (froggerAnimator.GetCurrentAnimatorStateInfo (0).IsName ("frog_jump_anim") &&
			    froggerAnimator.GetCurrentAnimatorStateInfo (0).normalizedTime < 1.0f) {

				transform.position = toBe ();

			}

			transform.rotation = Quaternion.Euler(0,0,0);
			froggerAnimator.SetTrigger ("forward");

		}else if (Input.GetKeyDown(downKey)){
			if (froggerAnimator.GetCurrentAnimatorStateInfo (0).IsName ("frog_jump_anim") &&
				froggerAnimator.GetCurrentAnimatorStateInfo (0).normalizedTime < 1.0f) {

				transform.position = toBe ();

			}

			transform.rotation = Quaternion.Euler(0,180,0);
			froggerAnimator.SetTrigger ("forward");
			// calculate Z translation 
			// Play child animation
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
			if (froggerAnimator.GetCurrentAnimatorStateInfo (0).IsName ("frog_jump_anim") &&
				froggerAnimator.GetCurrentAnimatorStateInfo (0).normalizedTime < 1.0f) {

				transform.position = toBe ();

			}
				
			transform.rotation = Quaternion.Euler(0,90,0);
			froggerAnimator.SetTrigger ("forward");



		} else if(Input.GetKeyDown(leftKey)){
			// left
			if (froggerAnimator.GetCurrentAnimatorStateInfo (0).IsName ("frog_jump_anim") &&
				froggerAnimator.GetCurrentAnimatorStateInfo (0).normalizedTime < 1.0f) {

				transform.position = toBe ();

			}

			transform.rotation = Quaternion.Euler(0,270,0);
			froggerAnimator.SetTrigger ("forward");
		}
			

	}

	Vector3 toBe(){
		Vector3 pos = transform.position;

		if (transform.rotation.eulerAngles.y == 0) {
			return new Vector3 (pos.x, pos.y, pos.z + 2.5f);
		} else if (transform.rotation.eulerAngles.y == 90) {
			return new Vector3 (pos.x + 2.5f, pos.y, pos.z);
		} else if (transform.rotation.eulerAngles.y == 180) {
			return new Vector3 (pos.x, pos.y, pos.z - 2.5f);
		} else if(transform.rotation.eulerAngles.y == 270){
			return new Vector3 (pos.x - 2.5f, pos.y, pos.z);
		}

		return Vector3.zero;

	}

	private bool  readynow = true;

	void  OnTriggerEnter ( Collider other  ){
		if(other.gameObject.tag == "Car"){

			if(readynow){
			Instantiate(blood, new Vector3(child.transform.position.x,0.55f,child.transform.position.z), Quaternion.identity);
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

		rend.SetActive (false);
		yield return new WaitForSeconds(1);

		// check if frogger respawns or dies
		if(GameManager.Instance.lives>0){
			GameManager.Instance.lives--;
            resetPos();
			print("Hit by a car! Froggers lives: " + GameManager.Instance.lives);	
		}else{
			Destroy (gameObject);
			Debug.Log("GAME OVER");
			Application.LoadLevel ("Start");
		}

		rend.SetActive (true);

		readynow=true;
	}



    public IEnumerator froggerCount()
    {

        readynow = false;

		rend.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(1);

        resetPos();

        GetComponent<BoxCollider>().enabled = true;
		rend.SetActive(true);

        readynow = true;
    }

    public void resetPos()
    {
        transform.position = startPos;
    }
}