using UnityEngine;
using System.Collections;

public class HitPointManager : MonoBehaviour {

    public int hitPoints;
    public int maxHitPoints;

	// Use this for initialization
	void Start () {
        hitPoints = maxHitPoints;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    internal void setHitPoints(int hp)
    {
        hitPoints = Mathf.Clamp(hp, 0, maxHitPoints);
    }

    internal int getHitPoints(int hp)
    {
        return hitPoints;
    }

    internal bool isDead()
    {
        return hitPoints <= 0;
    }

    internal void addHP(int value)
    {
        setHitPoints(hitPoints + value);
    }

    internal void subtractHP(int value)
    {
        setHitPoints(hitPoints - value);
    }
}
