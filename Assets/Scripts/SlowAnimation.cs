using UnityEngine;
using System.Collections;

public class SlowAnimation : MonoBehaviour {

	public float speed = 1;

	// Use this for initialization
	void Start () {
		GetComponent<Animator>().speed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
