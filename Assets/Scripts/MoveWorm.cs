using UnityEngine;
using System.Collections;

public class MoveWorm : MonoBehaviour {

	Animator anim;
	public GameObject spitPrefab;
	GameObject player;
	GameObject boss1;
	GameObject go1;
	GameObject go2;
	GameObject go3;
	GameObject go4;
	int facing = -1;
	string attack;
	
	LearningSystem ls;


	void Start () {
		anim = GetComponent<Animator>();
		ls = GetComponent<LearningSystem> ();
		
		player = GameObject.Find("Player");
		boss1 = GameObject.Find("GIANT_WORM");
		go1 = GameObject.Find("GameObject1");
		go2 = GameObject.Find("GameObject2");
		go3 = GameObject.Find("GameObject3");
		go4 = GameObject.Find("GameObject4");

	}



	void generateAttack() {
		int attack;
		attack = ls.getAttack();
		
		if (attack == 0) {
			Bite();
		}
		else if (attack == 1) {
			UndergroundBite();

		}
		else if (attack == 2) {
			Spit();

		}
		else if (attack == 3) {
			Puke ();

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

	void Bite(){
		attack = "bite";
		anim.SetTrigger ("disHigh0");

	} 

	void UndergroundBite(){
		attack = "undergroundbite";
		anim.SetTrigger ("disappearHigh");
	}
	

	void Spit(){
		attack = "spit";
		anim.SetTrigger ("disHigh2");
		GameObject pb = (GameObject)Instantiate (spitPrefab, new Vector3(500.35f,5.0f,520.92f),Quaternion.identity);
		Destroy (pb,2.5f);
	}

	void Puke(){
		attack = "roarpuke";
		anim.SetTrigger ("disHigh1");
	}

	void teleport() {
		if (attack == "bite") {
			boss1.transform.position = new Vector3(transform.position.x,transform.position.y,go4.transform.position.z);
		} 
		else if (attack == "undergroundbite"){
			boss1.transform.position = new Vector3(transform.position.x,transform.position.y,go2.transform.position.z);
		}
		
		else if (attack == "spit"){
			print ("HILLARY");
			int choice = Random.Range(1,3);
			if(choice == 1) {
				boss1.transform.position = new Vector3(transform.position.x,transform.position.y,go1.transform.position.z);
			}
			else {
				boss1.transform.position = new Vector3(transform.position.x,transform.position.y,go3.transform.position.z);
			}
		}
		
		else if (attack == "roarpuke"){
			print ("HI");
			int choice = Random.Range(1,3);
			if(choice == 1) {
				boss1.transform.position = new Vector3(transform.position.x,transform.position.y,go1.transform.position.z);
			}
			else {
				boss1.transform.position = new Vector3(transform.position.x,transform.position.y,go3.transform.position.z);
			}
		}
	}

	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (500,transform.position.y,transform.position.z) ;

		if (transform.position.z < player.transform.position.z)
		{
			setFacing(1);
		}
		else
		{
			setFacing(-1);
		}

		if (Input.GetKey ("up")) {
			//generateAttack ();
			Spit();
			//UndergroundBite ();
		}
	}
}
