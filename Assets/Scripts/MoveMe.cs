using UnityEngine;
using System.Collections;

public class MoveMe : MonoBehaviour {
	public float speed;

	void  FixedUpdate (){
		transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
	}
}