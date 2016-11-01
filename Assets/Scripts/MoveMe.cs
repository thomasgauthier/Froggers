using UnityEngine;
using System.Collections;

public class MoveMe : MonoBehaviour {
	float speed;

	void  FixedUpdate (){
		transform.position.x = transform.position.x + speed;
	}
}