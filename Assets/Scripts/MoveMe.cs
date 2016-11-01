using UnityEngine;
using System.Collections;

public class MoveMe : MonoBehaviour
{
		public float speed;
		private float initialSpeed;


		void Awake ()
		{
				initialSpeed = speed;
		}

		void  FixedUpdate ()
		{
				transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
		}

		public void ResetSpeed ()
		{
				speed = initialSpeed;
		}
}