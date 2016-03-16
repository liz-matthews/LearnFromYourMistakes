using UnityEngine;
using System.Collections;
using System;

public class PlayerControls : MonoBehaviour {

    EntityInfo entityInfo;
    public bool cheatsOn = true;
    public GameObject lookObject;
    public GameObject equippedGun;

   // GunManager ak47Manager;

    // Use this for initialization
    void Start ()
    {
        entityInfo = gameObject.GetComponent<EntityInfo>();
    }


    static public Vector3 GetPointToLine(Vector3 origin, Vector3 direction, Vector3 point){
        Vector3 point2origin = origin - point;
        Vector3 point2closestPointOnLine = point2origin - Vector3.Dot(point2origin,direction) * direction;
        return point2closestPointOnLine;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.z < lookObject.transform.position.z)
        {
            entityInfo.setFacing(1);
        }
        else
        {
            entityInfo.setFacing(-1);
        }
      
        // Set states
        if (Input.GetKey(KeyCode.S)) // Crouching
        {
            entityInfo.setState(3);
        }
        else if (Input.GetKey(KeyCode.D)) // Right
        {
            entityInfo.setState(1);

        }
        else if (Input.GetKey(KeyCode.A)) // Left
        {
            entityInfo.setState(2);

        }
        else  // Stop
        {
            entityInfo.setState(0);

        }

        if (Input.GetKey(KeyCode.W)) // Jump
        {
            entityInfo.jump();
        }

        Debug.Log("mousebutton? " + Input.GetMouseButton(0));

        if (Input.GetMouseButton(0)) // Left button click
        {
            if (equippedGun != null && equippedGun.GetComponent<GunManager>().canShoot())
            {
                Debug.Log("Pew\n");
            }
        }

        if (cheatsOn)
        {
            if (Input.GetKeyDown(KeyCode.CapsLock))
            {

                gameObject.GetComponent<HitPointManager>().addHP(1);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                gameObject.GetComponent<HitPointManager>().subtractHP(1);
            }
        }
    }
}
