//using UnityEngine;
//using System.Collections;
//
//public class FPSCollide : MonoBehaviour {
//
//		private Vector3 startPos;
//
//	// Use this for initialization
//	void Start () {
//				startPos = transform.position;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//
//		void  OnTriggerEnter ( Collider other  ){
//				if (other.gameObject.tag == "Car") {
//
//				}
//		}
//
//
//		IEnumerator  froggerHit (){
//
//
//				yield return new WaitForSeconds(1);
//
//				// check if frogger respawns or dies
//				if(lives>0){
//						transform.position = startPos; 		
//						lives--;
//						print("Hit by a car! Froggers lives: "+lives);	
//				}else{
//						Destroy (gameObject);
//						Debug.Log("GAME OVER");
//						Application.LoadLevel ("Start");
//				}
//
//
//		}
//}
