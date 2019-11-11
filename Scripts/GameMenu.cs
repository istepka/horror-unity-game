using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
    {

        [SerializeField] private Slider volumeSlider;
       // [SerializeField] private Slider difficultySlider;
        [SerializeField] private Slider brightnessSlider;
        [SerializeField] private Slider MouseSensSlider;
        [SerializeField] private TextMeshProUGUI volumeValueText;
       // [SerializeField] private TextMeshProUGUI DifficultyValueText;
        [SerializeField] private TextMeshProUGUI BrightValueText;
        [SerializeField] private TextMeshProUGUI SensValueText;
        [SerializeField] private GameObject menuPoupup;
        [SerializeField] private GameObject optionsMenu;


    bool menuOpened;

    public void Start()
    {
        menuOpened = false;
    }


     void Update()
        {
       // Debug.Log(MainMenu.brightVal);

           
            if(Input.GetKeyDown(KeyCode.Escape) && menuOpened != true)
                {
            Cursor.visible = true;

                MouseLook.sensitivityHor = 0;
                MouseLook.sensitivityVert = 0;


                    volumeSlider.value = MainMenu.volVal;
                    brightnessSlider.value = MainMenu.brightVal;
                    MouseSensSlider.value = MainMenu.sensVal;
                
                
                
                        Debug.Log("Menuopened");
                     menuPoupup.SetActive(true);
                     menuOpened = true;
                }
            else if (Input.GetKeyDown(KeyCode.Escape) && menuOpened == true)
            {
            Cursor.visible = false;

                MouseLook.sensitivityHor = MouseSensSlider.value;
                MouseLook.sensitivityVert = MouseSensSlider.value;

                MainMenu.volVal = volumeSlider.value;
                MainMenu.brightVal = brightnessSlider.value;
                MainMenu.sensVal = MouseSensSlider.value;

                optionsMenu.SetActive(false);
                menuPoupup.SetActive(false);
                menuOpened = false;
            }
        }

        public static void PoupupMenu()
        {
            
        }

        public void Resume()
        {
                Cursor.visible = false;

            MouseLook.sensitivityHor = MouseSensSlider.value;
            MouseLook.sensitivityVert = MouseSensSlider.value;

            MainMenu.volVal = volumeSlider.value;
            MainMenu.brightVal = brightnessSlider.value;
            MainMenu.sensVal = MouseSensSlider.value;


            menuPoupup.SetActive(false);
            menuOpened = false;
        }


        public void MainMenuBack()
        {
            SceneManager.LoadScene("MainMenu");
        }


        public void VolumeChanged()
        {
            Manager.overallVolume = volumeSlider.value;
            Manager.VolumeChanged(volumeSlider.value);
            float value = (int)(volumeSlider.value * 100);
            volumeValueText.text = value.ToString() + "%";



        }

        public void BrightnessChanged()
        {
            BrightnessManager.brightness = brightnessSlider.value;
            float val = (int)((brightnessSlider.value / 0.5f) * 100);
            BrightValueText.text = val.ToString() + "%";

        }

        public void SensitivityChanged()
        {
            MouseLook.sensitivityHor = MouseSensSlider.value;
            MouseLook.sensitivityVert = MouseSensSlider.value;

            float val = (int)(MouseSensSlider.value / 9 * 100);
            SensValueText.text = val.ToString() + "%";

        }




    }




