using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

	Vector3 pos;
	// Use this for initialization
	void Start () {
		GetComponent<Animation>().Play ("ariseHigh");
		StartCoroutine ("waitTime");

	}

	IEnumerator waitTime(){
		yield return new WaitForSeconds (2.0f);
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
		GetComponent<Animation> ().Play ("spitHigh");
		//Projectile code

		//Damage code
	}

	//Underground Bite attack
	void UndergroundBite(){
		//GetComponent<Animation> () ["disappearHigh"].wrapMode = WrapMode.Once;
		//GetComponent<Animation> ().Play ("disappearHigh");

		//pos = GameObject.Find("Player").transform.position;

		GetComponent<Animation> ().Play ("UndergroundBite");
		//Damage code
	}
	// Update is called once per frame
	void Update () {
		 //use it to test various animations
		 	if (Input.GetKey("up")){
			UndergroundBite ();
		}

	}
}
