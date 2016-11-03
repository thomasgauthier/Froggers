using UnityEngine;
using System.Collections;

public class TurtleDisappear : MonoBehaviour {

	public float upTime;
	public float downTime;

	// Use this for initialization
	void Start () {
		Invoke ("GoDown", upTime);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 center = transform.parent.GetComponent<BoxCollider> ().center;

		transform.parent.GetComponent<BoxCollider> ().center = new Vector3 (center.x, transform.localPosition.y, center.z);
	}

	void GoDown(){
		GetComponent<Animator> ().SetTrigger ("down");
		Invoke ("GoUp", downTime);
	}

	void GoUp(){
		GetComponent<Animator> ().SetTrigger ("up");
		Invoke ("GoDown", upTime);
	}
}
