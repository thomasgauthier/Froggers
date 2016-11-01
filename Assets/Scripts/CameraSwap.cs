
using UnityEngine;
using System.Collections;


public class CameraSwap : MonoBehaviour {
	public Camera Camera1;
	public Camera Camera2;

	void  Start (){
		Camera1.enabled = true;
		Camera2.enabled = false;

	}

	void  Update (){
		if(Input.GetKey("1")){
			Debug.Log("Using Camera One");
			activateCameraOne();
		}

		if(Input.GetKey("2")){
			Debug.Log("Using Camera Two");
			activateCameraTwo();
		}
	}

	void  activateCameraOne (){
		Camera1.enabled = false;
		Camera2.enabled = true;
	}

	void  activateCameraTwo (){
		Camera1.enabled = true;
		Camera2.enabled = false;
	}



}