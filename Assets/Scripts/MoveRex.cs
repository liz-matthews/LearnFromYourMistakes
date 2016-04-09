using UnityEngine;
using System.Collections;

public class MoveRex : MonoBehaviour {

	Animator anim;
	public GameObject fireballPrefab;

	// Use this for initialization

	/*	void ResetFlag(){
		Chk1 = 0;
	}*/



	void Start () {
		anim = GetComponent<Animator>();
	}

	void Fireball(){
		anim.SetTrigger ("spitFireball");

		GameObject fb = (GameObject)Instantiate (fireballPrefab, new Vector3(499.96f,3.63f,515.0f), Quaternion.identity);
		Destroy (fb,2.5f);
		//Damage code

	}

	void Bite(){
		anim.SetTrigger ("bite");
	}

	void SpreadFire(){
		anim.SetTrigger ("spreadFire");
	}

	void TailAttack(){
		anim.SetTrigger ("tailAttack");
	}

	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey ("up"))
			Fireball ();

		if (Input.GetKey ("down"))
			Bite ();

		if (Input.GetKey ("right"))
			 SpreadFire ();

		if (Input.GetKey ("left"))
			TailAttack ();


		
	}
}
