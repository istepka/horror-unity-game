using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioPlayerController : MonoBehaviour {

    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource source;
    [SerializeField] private GameObject playerObject;


    float _deltaTime = 0;


	void Start () {
		


	}
	
	
	void Update () {
        _deltaTime += Time.deltaTime;

        if(_deltaTime > 5f)
        {
            float distance = Vector3.Distance(gameObject.transform.position, playerObject.transform.position);

            if(distance < 10)
            {
                if(!source.isPlaying)
                {
                    source.Play();
                }

                distance /= 10;
                source.volume = distance;
            }
            else if (distance > 10)
            {
                if (source.isPlaying)
                    source.Stop();
            }

            _deltaTime = 0;


        }


	}
}
