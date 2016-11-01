
using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {
	/*
This camera smoothes out rotation around the y-axis and height.
Horizontal Distance to the target is always fixed.

There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.

For every of those smoothed values we calculate the wanted value and the current value.
Then we smooth it using the Lerp function.
Then we apply the smoothed values to the transform's position.
*/

	// The target we are following
	Transform target;
	// The distance in the x-z plane to the target
	FIXME_VAR_TYPE distance= 10.0f;
	// the height we want the camera to be above the target
	FIXME_VAR_TYPE height= 5.0f;
	// How much we 
	FIXME_VAR_TYPE heightDamping= 2.0f;
	FIXME_VAR_TYPE rotationDamping= 3.0f;

	// Place the script in the Camera-Control group in the component menu
	@script AddComponentMenu("Camera-Control/Smooth Follow")


	void  LateUpdate (){
		// Early out if we don't have a target
		if (!target)
			return;

		// Calculate the current rotation angles
		FIXME_VAR_TYPE wantedRotationAngle= target.eulerAngles.y;
		FIXME_VAR_TYPE wantedHeight= target.position.y + height;

		FIXME_VAR_TYPE currentRotationAngle= transform.eulerAngles.y;
		FIXME_VAR_TYPE currentHeight= transform.position.y;

		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		// Convert the angle into a rotation
		FIXME_VAR_TYPE currentRotation= Quaternion.Euler (0, currentRotationAngle, 0);

		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;

		// Set the height of the camera
		transform.position.y = currentHeight;

		// Always look at the target
		transform.LookAt (target);
	}
}