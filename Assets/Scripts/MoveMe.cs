using UnityEngine;
using System.Collections;

public class MoveMe : MonoBehaviour {
		public float speed;

		private float initSpeed;

		void Awake(){
				initSpeed = speed;
		}

		void  FixedUpdate (){
				Rigidbody rb = GetComponent<Rigidbody> ();
				rb.velocity = Vector3.right * speed;
		}

		public void ResetSpeed(){
				speed = initSpeed;
		}
}