using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Light flashlight;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip s_switchFLashlight;
    [SerializeField] private  GameObject player;
    //   [SerializeField] AudioClip s_step;


    //[SerializeField] UIController uiController;
    public static Vector3 playerPosition;
    private float intensity = 1;

    public static void savePlayerPosition()
    {
        SaveGame.PlayerPosition = playerPosition;
    }



    void Start()
    {
        playerPosition = player.transform.position;


        intensity = flashlight.intensity;
        //flashlight.intensity = 28;
    }


    void Update()
    {
        playerPosition = player.transform.position;
        if (Input.GetMouseButtonDown(1))
        {
            soundSource.PlayOneShot(s_switchFLashlight);
            if (flashlight.intensity != 0)
            {
                flashlight.intensity = 0;
                UIController.flashlightOnFlag = false;
            }
            else
            {
                flashlight.intensity = intensity;
                UIController.flashlightOnFlag = true;
            }
        }

      

    }



}
