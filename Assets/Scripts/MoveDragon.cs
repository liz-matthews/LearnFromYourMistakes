using UnityEngine;
using System.Collections;

public class MoveDragon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Animation>().Play("landing");
		StartCoroutine ("waitTime");
	}

	IEnumerator waitTime(){
		yield return new WaitForSeconds (1.8f);
		GetComponent<Animation> ().Play ("idle");
	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Player") {
			GetComponent<Animation> ().Play ("bite");
			//Add code for damage
			StartCoroutine ("waitTime");
		}
	}

	void Fireball (){
		bool chk = true;

		if (chk) {
			GetComponent<Animation> ().wrapMode = WrapMode.Once;
			GetComponent<Animation> ().Play ("goInAir");
			chk = false;
		}

		GetComponent<Animation> ().Play ("flySpitFireball");
	}
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey("up"))
			Fireball ();
	}
}
