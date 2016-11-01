using UnityEngine;
using System.Collections;

public class Warparound : MonoBehaviour {
	float worldWidth;
	private Vector3 resetPos;

	void  Start (){
		resetPos = transform.position;	
	}

	void  Update (){

		/* Warp Zone */
		if(transform.position.x > worldWidth) transform.position.x = -worldWidth;
		if(transform.position.x < -worldWidth) transform.position.x = worldWidth;

		/* Reset Position */
		if(transform.position.y < -5) transform.position = resetPos;
	}
}