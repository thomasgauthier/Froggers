using UnityEngine;
using System.Collections;

public class MoveMeFrogCar : MonoBehaviour {

	private float initSpeed;
	private float startColliderX;

	private Animator frogAnimator;
	private GameObject child;

	public float speed = 1;

	void Awake(){
		initSpeed = speed;

		frogAnimator = transform.GetComponentInChildren<Animator> ();


		child = GetComponentInChildren<Animator> ().gameObject;
	}

	void Start(){
		startColliderX = GetComponent<BoxCollider> ().center.x;
	}

	void  FixedUpdate (){
//		Rigidbody rb = GetComponent<Rigidbody> ();
//		rb.velocity = Vector3.right * speed;
	}

	void Update(){

		frogAnimator.speed = speed;

		Vector3 colCenter = GetComponent<BoxCollider> ().center;
		GetComponent<BoxCollider> ().center = new Vector3 (startColliderX + child.transform.localPosition.x, colCenter.y, colCenter.z);


		if (frogAnimator.GetCurrentAnimatorStateInfo (0).IsName ("frog_car_jump") &&
			frogAnimator.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1.0f) {

			Vector3 pos = transform.position;
			Vector3 childPos = child.transform.localPosition;

			if (transform.rotation.eulerAngles.y == 0) {
				transform.position = new Vector3 (pos.x + childPos.x, pos.y, pos.z);
			} else if (transform.rotation.eulerAngles.y == 180) {
				transform.position = new Vector3 (pos.x - childPos.x, pos.y, pos.z);
			}



			child.transform.localPosition = new Vector3 (0, childPos.y, childPos.z);

			frogAnimator.SetTrigger ("idle");
			GetComponent<BoxCollider> ().center = new Vector3 (startColliderX, colCenter.y, colCenter.z);

		}

		if (frogAnimator.GetCurrentAnimatorStateInfo (0).IsName ("idle")){

			frogAnimator.SetTrigger ("forward");

			}
	}

	public void ResetSpeed(){
		speed = initSpeed;
	}
}