using UnityEngine;
using System.Collections;

public class MoveRex : MonoBehaviour {

	Animator anim;
	public GameObject fireballPrefab;
	GameObject player;
	GameObject boss2;
	GameObject go1;
	GameObject go2;
	GameObject go3;
	CharacterController character;
	int facing = -1;
	string attack;
	
	LearningSystem ls;


	void Start () {
		anim = GetComponent<Animator>();
		ls = GetComponent<LearningSystem>();
		character = GetComponent<CharacterController>();
		
		player = GameObject.Find("Player");
		boss2 = GameObject.Find("DRAGON_REX_ALPHA");
		go1 = GameObject.Find("GameObject1");
		go2 = GameObject.Find("GameObject2");
		go3 = GameObject.Find("GameObject3");
	}

	void generateAttack() {
		int attack;
		attack = ls.getAttack();
		
		if (attack == 0) {
			Bite();
		}
		else if (attack == 1) {
			TailAttack();
			
		}
		else if (attack == 2) {
			Fireball();
			
		}
		else if (attack == 3) {
			SpreadFire ();
			
		}
	}
	
	internal void setFacing(int f)
	{
		if (facing != f)
		{
			facing = f;
			transform.Rotate(Vector3.up * 180);
		}
	}

//	void MoveToPoint() {
//		anim.SetTrigger ("walk");
//		Vector3 targetPosition = go3.transform.position;
//
//		if ((targetPosition - transform.position).magnitude < 1) {
//			anim.SetTrigger ("death");
//			return;
//		}
//
//		Vector3 movDiff = targetPosition - transform.position;
//		Vector3 movDir = movDiff.normalized * 25f * Time.deltaTime;
//
//		if (movDir.sqrMagnitude < movDiff.sqrMagnitude) {
//			character.Move (movDir);
//		} else {
//			character.Move (movDiff);
//		}
//	}


	void Bite(){
		attack = "bite";
		anim.SetTrigger ("bite");
	}

	void TailAttack(){
		attack = "tailAttack";
		anim.SetTrigger ("tailAttack");
	}

	void Fireball(){
		attack = "spitFireball";
		anim.SetTrigger ("spitFireball");
		
		GameObject fb = (GameObject)Instantiate (fireballPrefab, new Vector3(499.96f,3.63f,515.0f), Quaternion.identity);
		Destroy (fb,2.5f);
	}

	void SpreadFire(){
		attack = "spreadFire";
		anim.SetTrigger ("spreadFire");
	}

	void teleport() {
		if (attack == "bite") {
			boss2.transform.position = new Vector3(transform.position.x,go3.transform.position.y,go3.transform.position.z);
		} 
		else if (attack == "tailAttack"){
			boss2.transform.position = new Vector3(transform.position.x,go3.transform.position.y,go3.transform.position.z);
		}
		
		else if (attack == "spitFireball"){
			int choice = Random.Range(1,3);
			if(choice == 1) {
				boss2.transform.position = new Vector3(transform.position.x,0,go1.transform.position.z);
			}
			else {
				boss2.transform.position = new Vector3(transform.position.x,0,go2.transform.position.z);
			}
		}
		
		else if (attack == "spreadFire"){
			int choice = Random.Range(1,3);
			if(choice == 1) {
				boss2.transform.position = new Vector3(transform.position.x,0,go1.transform.position.z);
			}
			else {
				boss2.transform.position = new Vector3(transform.position.x,0,go2.transform.position.z);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (0, transform.position.y, transform.position.z);


		if (transform.position.z < player.transform.position.z)
		{
			setFacing(1);
		}
		else
		{
			setFacing(-1);
		}
		
		if (boss2.GetComponent<HitPointManager> ().isDead()) {
			anim.SetTrigger ("death");
		}
	
		if (Input.GetKey ("up")) {
			Fireball ();
		}

		if (Input.GetKey ("down")) {
			Bite ();
		}

		if (Input.GetKey ("right")) {
			SpreadFire ();
		}

		if (Input.GetKey ("left")) {
			TailAttack ();
		}
	}
}
