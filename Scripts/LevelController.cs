using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    [SerializeField] private Text notification;
    [SerializeField] private Image EndingTransitionImage;
    [SerializeField] private GameObject EndingTransitionElement;
    [SerializeField] private GameObject Player;
    [SerializeField] private AudioSource PlayerAudioSource;
    [SerializeField] private AudioClip earSqueel;

    public static bool gateOpenStatus = false;
    private bool flag = false;
    public int findGoal = 5;
    public static bool gateOpenedByPlayer = false;

    Vector4 colorEndtrans = new Vector4(255, 255, 255, 0);
	
	void Start () {

     

    }
	
	
	void Update () {
        if (CollectingSystem.collected == findGoal && flag == false)
        {
            gateOpenStatus = true;

            Debug.Log("Gate has been opened");
            notification.text = "Gate has been opened";
            
            StartCoroutine(clearText());
        }

        if (gateOpenedByPlayer == true)
        {
            
            PlayerAudioSource.PlayOneShot(earSqueel);
            FPSInput.blockMoving = true;
            

            EndingTransitionImage.color = colorEndtrans;
            EndingTransitionElement.SetActive(true);
            StartCoroutine(endTransition());
        }


    }

    private IEnumerator clearText()
    {
        flag = true;
        yield return new WaitForSeconds(2);
        notification.text = "";
    }

     //float timeElapsed = 0;

    private IEnumerator endTransition()
    {
       

        while (colorEndtrans.w < 10 )
        {
            Debug.Log(colorEndtrans.w);
            colorEndtrans.w+= 0.0001f;
            Player.transform.Rotate(0.0001f, 0, 0.0007f);
            Player.transform.Translate(0, -0.00001f, 0);

            if (colorEndtrans.w > 2.2f)
                loadlevel();

            yield return null;
        }

       

    }

    void loadlevel()
    {
        SceneManager.LoadScene("Hospital");
    }


}
