using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour {
    
    public float bulletDelay;
    float currentTime;
      
    // Use this for initialization
    void Start () {
        currentTime = bulletDelay;
	
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

        }

        return retVal;
    }


}
