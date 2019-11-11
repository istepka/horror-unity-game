using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
	



	void Start () {
		
	}
	
	
	void Update () {
        if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && source.isPlaying == false)
        {
           
            source.PlayOneShot(clip);
        }

    }
}
