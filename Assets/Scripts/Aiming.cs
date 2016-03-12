using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour {
    
    public GameObject mainCharacter = null;
    CharacterController mainCharController;
    public GameObject aimPoint = null;
    

    float heightOffset;
    float widthOffset;
    float aimingRadius;


	// Use this for initialization
	void Start () {

        heightOffset = 0.5f;
        aimingRadius = 0.7f;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (mainCharacter && aimPoint)
        {

            mainCharController = mainCharacter.GetComponent<CharacterController>();

            Vector3 origin = mainCharacter.transform.TransformPoint(mainCharController.center);
            origin.y += mainCharController.height / 2 - 0.2f; // - (heightOffset * mainCharacter.transform.localScale.y);
            
            Vector3 aimingVector = aimPoint.transform.position - origin;
            aimingVector.Normalize();
            aimingVector *= aimingRadius * mainCharacter.transform.localScale.y;

            gameObject.transform.position = origin + aimingVector;
            gameObject.transform.LookAt(origin + aimingVector * 2);
        }


    }


}
