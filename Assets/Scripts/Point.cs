using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour
{

    bool consumed = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        //debounce
        if(other.gameObject.tag == "Player" && !consumed)
        {
            transform.GetChild(0).gameObject.SetActive(true);

			if (other.gameObject.GetComponent<Frogger> ()) {
				other.gameObject.GetComponentInChildren<Animator>().SetTrigger("idle");
				StartCoroutine (other.gameObject.GetComponent<Frogger> ().froggerCount ());
			} else {
				StartCoroutine (other.gameObject.GetComponent<FroggerFPS> ().froggerCount ());
			}

            GameManager.Instance.points++;
            consumed = true;
        }
    }


}