using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubtitlesScene : MonoBehaviour {

    [SerializeField] private AudioSource audiosource;
    [SerializeField] private GameObject backMessage;
    

    float timeElapsed = 0f;

	void Start () {
        
        audiosource.volume = Manager.overallVolume - 0.3f;
        audiosource.Play();
	}
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > 25)
            backMessage.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.visible = true;
            SceneManager.LoadScene("MainMenu");
        }
        }
}
