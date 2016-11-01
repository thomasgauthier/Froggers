using UnityEngine;
using System.Collections;

public class MoveRigidbody : MonoBehaviour {
	float speed;

	void  Update (){
		GetComponent<Rigidbody>().velocity = new Vector3(speed,0,0);
	}
}