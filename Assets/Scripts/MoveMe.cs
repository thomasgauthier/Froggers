using UnityEngine;
using System.Collections;

public class MoveMe : MonoBehaviour
{
	public float speed;

	private float initSpeed;
	public bool useRigidbody = true;

	void Awake ()
	{
		initSpeed = speed;
	}

	void  FixedUpdate ()
	{
		if (useRigidbody) {
			Rigidbody rb = GetComponent<Rigidbody> ();
			rb.velocity = Vector3.right * speed;
		} else {
			Vector3 pos = transform.position;
			transform.position = new Vector3 (pos.x + speed * Time.fixedDeltaTime, pos.y, pos.z);
		}
	}

	public void ResetSpeed ()
	{
		speed = initSpeed;
	}
}