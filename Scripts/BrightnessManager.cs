using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessManager : MonoBehaviour {

    [SerializeField] private Light mainLight;


    public static float brightness = 1f;

    public void Start()
    {
        mainLight.intensity = brightness;
    }
    private void Update()
    {
        mainLight.intensity = brightness;   
    }



}
