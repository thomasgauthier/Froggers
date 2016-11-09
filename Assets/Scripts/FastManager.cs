using UnityEngine;
using System.Collections;

public class FastManager : MonoBehaviour {

	public Transform frogger;
	public GameObject[] cars;
	public Vector3[] startPos;

	public AudioSource audioSource;

	private float startZ;
	//	public AudioClip cars;
	bool played = false;
	// Use this for initialization
	void Start () {
		startZ = frogger.position.z;

		startPos = new Vector3[cars.Length];

		for(int i = 0; i < cars.Length; i++)
 {
			startPos [i] = cars[i].transform.position;
			}

	}

	// Update is called once per frame
	void Update () {
		for(int i = 0; i < cars.Length; i++)
		{
			if (cars[i].transform.position.x > 55f) {
				cars[i].transform.position = startPos [i];
//				cars [i].GetComponent<MoveMe> ().enabled = false;
//				cars [i].GetComponent<Rigidbody> ().velocity = Vector3.zero;
//				cars[i].GetComponent<AudioSource> ().Stop ();

				//played = false;
			}	
		}


		if (!played) {

		if (frogger.position.z > startZ) {
			foreach (var car in cars) {
				car.GetComponent<MoveMe> ().enabled = true;
			}

				//audioSource.Play ();
				foreach (var car in cars) {
					car.GetComponent<AudioSource> ().Play ();
				}
				played = true;
			}
		}

	}
}
