using UnityEngine;
using System.Collections;
using System;

public class PlayerControls : MonoBehaviour {

    EntityInfo entityInfo;
    public bool cheatsOn = true;

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

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 characterPosition = transform.position;
        Vector3 closestPoint = GetPointToLine(ray.origin, ray.direction, characterPosition) + characterPosition;
      
        if (characterPosition.z < closestPoint.z)
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

        if (cheatsOn)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                gameObject.GetComponent<HitPointManager>().addHP(1);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                gameObject.GetComponent<HitPointManager>().subtractHP(1);
            }
        }
    }
}
