using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hospital : MonoBehaviour {


    [SerializeField] private Image img;
    Vector4 color = new Vector4(0,0,0,0);
    float timeElapsed = 0;

	void Start () {
      

	}

     void Update()
    {
      //  timeElapsed += Time.deltaTime;
    /*
        if(color.w > 0 && timeElapsed < 3.9)
        {
            color.w = color.w -  1;
            img.color = color;
            Debug.Log(color.w + " " + img.color);

        }
        else if (timeElapsed >= 3.9f && timeElapsed <=4)
        {
            img.color = new Vector4(0, 0, 0, 0);
        }
        else if (color.w < 255 && timeElapsed > 4)
        {
        */
          
            color.w += 0.0017f;
            img.color = color;
        Debug.Log(color.w);


        if (color.w > 1.5f)
            SceneManager.LoadScene("Subtitles");
        
    }

    

   
  




}
