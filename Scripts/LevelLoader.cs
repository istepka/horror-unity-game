using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour {


    public void LoadLevel(string name)
    {
        StartCoroutine(LoadAsynchronously(name));   
    }

    IEnumerator LoadAsynchronously(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);


        while (!operation.isDone)
        {
            Debug.Log(operation.progress);

            yield return null;
        }
    }


}
