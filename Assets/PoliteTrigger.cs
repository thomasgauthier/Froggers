using UnityEngine;
using System.Collections;

public class PoliteTrigger : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void  OnTriggerEnter (Collider other)
		{
				transform.parent.GetComponent<MoveMe> ().speed = 0;
		}


		void OnTriggerExit (Collider other)
		{
				transform.parent.GetComponent<MoveMe> ().ResetSpeed ();
		}
}
