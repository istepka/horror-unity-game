using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadingSubtitlesScript : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI textBox;

    private void Start()
    {
        GetComponent<TextMeshPro>();
    }

    //NOT WORKING SCRIPT
    public  void PlaySubtitles()
    {


    }


    private IEnumerator fadeCoroutine()
    {


        yield return null;
    }




}
