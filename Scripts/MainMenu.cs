using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private Slider brightnessSlider;
    [SerializeField] private Slider MouseSensSlider;
    [SerializeField] private TextMeshProUGUI volumeValueText;
    [SerializeField] private TextMeshProUGUI DifficultyValueText;
    [SerializeField] private TextMeshProUGUI BrightValueText;
    [SerializeField] private TextMeshProUGUI SensValueText;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadSlider;


    public static float sensVal;
    public static float diffVal;
    public static float brightVal;
    public static float volVal;





    public void Start()
    {
        Cursor.visible = true;
        sensVal = MouseSensSlider.value;
        diffVal = difficultySlider.value;
        brightVal = brightnessSlider.value;
        volVal = volumeSlider.value;


    }


    public void PlayGame()
    {
        BrightnessManager.brightness = brightVal;
        LoadLevel("Game");
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }



    public void LoadLevel(string name)
    {
        StartCoroutine(LoadAsynchronously(name));
        
    }

    IEnumerator LoadAsynchronously(string name)
        {
            
            AsyncOperation operation = SceneManager.LoadSceneAsync(name);
            loadingScreen.SetActive(true);
            gameObject.SetActive(false);


            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                loadSlider.value = progress;

                yield return null;
            }
    }



    public void VolumeChanged()
    {
        Manager.overallVolume = volumeSlider.value;
        Manager.VolumeChanged(volumeSlider.value);
        float value = (int)(volumeSlider.value * 100);
        volumeValueText.text = value.ToString() + "%";

        volVal = volumeSlider.value;


     
    }


    public void DifficultyChamged()
    {
        if (difficultySlider.value == 1)
        {
            UIController.difficulty = UIController.Difficulty.easy;
            DifficultyValueText.text = "Easy";
        }
        else if (difficultySlider.value == 2)
        {
            UIController.difficulty = UIController.Difficulty.medium;
            DifficultyValueText.text = "Normal";
        }
        else
        {
            UIController.difficulty = UIController.Difficulty.hard;
            DifficultyValueText.text = "Hard";
        }


        diffVal = difficultySlider.value;

    }

    public void BrightnessChanged()
    {
        BrightnessManager.brightness = brightnessSlider.value;
        float val = (int)((brightnessSlider.value / 0.5f )* 100);
        BrightValueText.text = val.ToString() + "%";

        brightVal = brightnessSlider.value;
      
    }

    public void SensitivityChanged()
    {
        MouseLook.sensitivityHor = MouseSensSlider.value;
        MouseLook.sensitivityVert= MouseSensSlider.value;

        float val = (int)(MouseSensSlider.value / 9 * 100);
        SensValueText.text = val.ToString() + "%";

        sensVal = MouseSensSlider.value;

    }

  


}
