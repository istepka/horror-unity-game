using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingSystem : MonoBehaviour {

    public static int collected;

	void Start () {
        collected = 0;	
	}
	
	void Update () {

      
	}

    public int getScore()
    {
        return collected;
    }

    public void setScore()
    {
        collected += 1;
    }

}
