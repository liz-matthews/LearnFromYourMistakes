using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour {
    
    public float bulletDelay;
    public float aimDistance;
    float currentTime;
    Aiming aiming;
      
    // Use this for initialization
    void Start () {
        currentTime = bulletDelay;
        aiming = gameObject.GetComponent<Aiming>();
	
	}

    // Update is called once per frame
    public void Update()
    {
        currentTime += Time.deltaTime;
    }

    internal bool canShoot()
    {
        bool retVal = currentTime >= bulletDelay;
        if (retVal)
        {
            currentTime = 0;
        } else
        {
            float lerp = currentTime / bulletDelay;
            if (lerp > 1.0f)
            {
                lerp = 1.0f;
            }

            aiming.setRadius(lerp);
        }

        return retVal;
    }


}
