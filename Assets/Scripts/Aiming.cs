using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour {
    
    public GameObject mainCharacter = null;
    CharacterController mainCharController;
    public GameObject aimPoint = null;
    

    public float heightOffset;
    public float widthOffset;
    public float aimingRadius;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (mainCharacter && aimPoint)
        {

            mainCharController = mainCharacter.GetComponent<CharacterController>();

            Vector3 origin = mainCharacter.transform.TransformPoint(mainCharController.center);
            origin.y += mainCharController.height / 2 - heightOffset;
            origin.x += widthOffset * mainCharacter.GetComponent<EntityInfo>().getFacing();
            
            Vector3 aimingVector = aimPoint.transform.position - origin;
            aimingVector.Normalize();
            aimingVector *= aimingRadius * mainCharacter.transform.localScale.y;

            gameObject.transform.position = origin + aimingVector;
            gameObject.transform.LookAt(origin + aimingVector * 2);
        }


    }


}
