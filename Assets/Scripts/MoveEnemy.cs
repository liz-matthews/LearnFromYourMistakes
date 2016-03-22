using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

	Vector3 pos;

	public Transform playr;

	// Use this for initialization
	void Start () {
		GetComponent<Animation>().Play ("ariseHigh");
		StartCoroutine ("waitTime");

	}

	IEnumerator waitTime(){
		
		yield return new WaitForSeconds (2.0f);
		GetComponent<Animation> ().Play ("idleBreatheHigh");
	}

	IEnumerator biteTime(){
		yield return new WaitForSeconds (1.25f);
		transform.position = new Vector3 (500.0f, 0.0f, 519.7f);
	//	GetComponent<Animation>().Play ("ariseHigh");
	//	yield return new WaitForSeconds (5.0f);
		GetComponent<Animation> ().Play ("idleBreatheHigh");
	}

	//Bite Attack
	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Player") {
			GetComponent<Animation> ().Play ("biteHigh");
			//Add code for damage
			StartCoroutine ("waitTime");
		}
	}

	//Mudball Attack
	void Mudball(){
		GetComponent<Animation> ().wrapMode = WrapMode.Once;
		GetComponent<Animation> ().Play ("spitHigh");

		//Projectile code

		//Damage code

		StartCoroutine ("waitTime");
	}

	//Underground Bite attack
	void UndergroundBite(){
		transform.position = playr.transform.position;
		GetComponent<Animation> ().Play ("UndergroundBite");
		//Damage code

		StartCoroutine ("biteTime");
	}
		
	// Update is called once per frame
	void Update () {
		 //use it to test various animations
		 	if (Input.GetKey("up"))
			UndergroundBite ();

			if (Input.GetKey("down"))
				Mudball ();


	}
}
