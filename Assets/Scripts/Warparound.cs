using UnityEngine;
using System.Collections;

public class Warparound : MonoBehaviour
{
		public float worldWidth;
		private Vector3 resetPos;

		void  Start ()
		{
				resetPos = transform.position;	
		}

		void  Update ()
		{

				/* Warp Zone */
				if (transform.position.x > worldWidth) {
						transform.position = new Vector3 (-worldWidth, transform.position.y, transform.position.z);
				}

				if (transform.position.x < -worldWidth) {
						transform.position = new Vector3 (worldWidth, transform.position.y, transform.position.z);
				}

				/* Reset Position */
				if (transform.position.y < -5)
						transform.position = resetPos;
		}
}