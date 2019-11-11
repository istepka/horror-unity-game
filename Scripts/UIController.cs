using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField] private Text scoreLabel;
    [SerializeField] private CollectingSystem collectingSystem;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject player;
    [SerializeField] private Text collectNotification;
    [SerializeField] private Image batteryIMG;
    [SerializeField] private Text batteryPercentage;
    [SerializeField] private Sprite[] batteryImages = new Sprite[5];
    [SerializeField] private Text notificationBox;
    [SerializeField] private GameObject miniMap;
    

    public float maxRayDistance = 4.5f;
   

    public  enum Difficulty
    {
        easy  = 3,
        medium = 2,
        hard =1
    }


    public  static Difficulty difficulty = Difficulty.medium;

    private float batteryTimeElapsed = 0f;
    private int batteryValue = 100;

    public static bool flashlightOnFlag = true;

     private int _score;

	void Start () {

        Cursor.visible = false;
        _score = 0;
        batteryIMG.sprite = batteryImages[0];

        

        GetComponent<CollectingSystem>();
        GetComponent<Camera>();
	}


    void Update() {
        _score = collectingSystem.getScore();   //SCORE 
        scoreLabel.text = _score.ToString();

       
            createRay();        //Constantly checking what's on ray

        if(batteryValue >= 1)
            batteryController();


        if(Input.GetKeyDown(KeyCode.M))
        {
            miniMap.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.M))
        {
            miniMap.SetActive(false);
        }

        
    }


    public  void createRay()
    {

            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2);
           // Debug.Log("casting: " + _camera.pixelWidth / 2 + ", " + _camera.pixelHeight / 2);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ClipboardController target = hitObject.GetComponent<ClipboardController>();
                DoorOpenDevice hitDoor = hitObject.GetComponent<DoorOpenDevice>();

            float distance = Vector3.Distance(player.transform.position, hitObject.transform.position);

            if (target != null && distance <= maxRayDistance)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    target.reactToHit();        //Reaction to hit 
                    collectingSystem.setScore();
                    StartCoroutine(collectNot());   //Notification collected
                    Debug.Log("Collected");



                }
                else
                {
                    collectNotification.text = "Press 'E' to collect clipboard";

                }
            }
            else if (hitDoor != null && distance <= maxRayDistance)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hitDoor.Operate();

                }
                else
                {
                    collectNotification.text = "Press 'E' to open";

                }

            }
            else
            {
               
                    collectNotification.text = "";
            }
            

            }

    }

    private IEnumerator collectNot()
    {
        notificationBox.text = "Clipboard collected";
        yield return new WaitForSeconds(2);
        notificationBox.text = "";
        collectNotification.text = "";
    }


    public void batteryController() //TODO
    {
        if(flashlightOnFlag == true)
        {
            batteryTimeElapsed += Time.deltaTime;
        }

     //   Debug.Log((int)batteryTimeElapsed);
       

        if ((int)batteryTimeElapsed == 5 * (int)difficulty)
        {
            Debug.Log("BatteryValue changed to: " + batteryValue);
            batteryTimeElapsed = 0;
            batteryValue--;
            batteryPercentage.text = batteryValue + "%";

            if(batteryValue == 75)
            {
                batteryIMG.sprite = batteryImages[1];
            }
            else if (batteryValue == 50)
            {
                batteryIMG.sprite = batteryImages[2];
            }
            else if (batteryValue == 25)
            {
                batteryIMG.sprite = batteryImages[3];
            }
            else if (batteryValue == 0)
            {
                batteryIMG.sprite = batteryImages[4];
            }

        }
    }
}
      

	









