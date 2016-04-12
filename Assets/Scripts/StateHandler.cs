using UnityEngine;
using System.Collections;


class StateInfo
{
    bool done;
    double timer;
    double totalTime;
    string stateName;

    StateInfo(string sn, double tt)
    {
        stateName = sn;
        totalTime = tt;
        timer = 0;
        done = false;
    }

    void setDone(bool d)
    {
        done = d;
    }

    bool isDone()
    {
        return false;
    }

    void resetTimer()
    {
        timer = 0;
    }

   
    void Update(double elapsedTime)
    {
        timer += elapsedTime;
    }

}

public class StateHandler : MonoBehaviour {

    int state;

	// Use this for initialization
	void Start () {
        state = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
