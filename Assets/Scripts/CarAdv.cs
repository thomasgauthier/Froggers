
using UnityEngine;
using System.Collections;

public class CarAdv : MonoBehaviour {
	public float EndOfWorld;
	public float minDist;
	private float speed;

	void  Start (){
		speed = Random.Range(0.5f,2.0f);
	}

	void  Update (){

		if(transform.position.x > EndOfWorld) {
			// move to the left
			transform.Translate(Vector3.left * Time.deltaTime * speed);

		}else{
			// end of world
			Destroy (gameObject);
		}

		// http://www.unity3dstudent.com/2010/08/intermediate-i01-raycasting/
		// draw ray
		RayCast right= transform.TransformDirection(Vector3.right);
		RaycastHit hit;    
		Debug.DrawRay(transform.position, -right * minDist, Color.green);

		// check ray hit
		if(Physics.Raycast(transform.position, -right, hit, minDist)){
			if(hit.collider.gameObject.tag == "Car"){

				// change speed to car speed infront
				Script targetScript = hit.collider.gameObject.GetComponent<"Car">();
				speed = targetScript.getSpeed();
			}
		}
	}

	void  getSpeed (){
		return speed;
	}
}