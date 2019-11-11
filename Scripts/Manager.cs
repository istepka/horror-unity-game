using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {



    private static float rgbVal = 0.5f;

    public static float overallVolume = 0.5f;

	
	void Start () {
        AudioListener.volume = overallVolume;
	}
	

	public static void VolumeChanged(float val)
    {
        overallVolume = val;
        AudioListener.volume = overallVolume;
    }



}
