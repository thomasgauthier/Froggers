using UnityEngine;
using System.Collections;

public class MainGameScript : MonoBehaviour {
	public GameObject car;
	public float CarSpawnDelay;

	bool  readynow = true;
	// http://www.unity3dstudent.com/2010/09/beginner-b22-pausing-scripts-with-waitforseconds/

	void  Update (){
		if(readynow){
			CreateCars();
		} 
	}

	void  CreateCars (){

		readynow=false;

		// create a new car
		FIXME_VAR_TYPE track= Random.Range(0,-4);
		Debug.Log(track);
		FIXME_VAR_TYPE car= Instantiate(car,Vector3(8,2,(track*4)), Quaternion.identity);

		// create timer delay
		float waitTime = Random.Range(0.1f,CarSpawnDelay);
		yield return new WaitForSeconds(waitTime);

		readynow=true;
	}
}