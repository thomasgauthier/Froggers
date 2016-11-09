using UnityEngine;
using System.Collections;

public class Volume : MonoBehaviour {

	public Transform frogger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		AnimationCurve curve = GetComponent<AudioSource> ().GetCustomCurve (AudioSourceCurveType.CustomRolloff);

		float distance = Mathf.Abs (transform.position.z - frogger.position.z);

		float maxDistance = GetComponent<AudioSource> ().maxDistance;

		GetComponent<AudioSource> ().volume = curve.Evaluate (distance / maxDistance);
	}
}
