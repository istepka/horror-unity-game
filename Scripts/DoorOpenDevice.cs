using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpenDevice : MonoBehaviour {

    [SerializeField] private Vector3 doorPos;
    [SerializeField] private Vector3 doorRot;
    [SerializeField] private Animator Player;

    public Text notification;

    private bool _open;
    private bool coolFlag = false;
    
  

    public void Operate()
    {
        if (gameObject.name == "gate" && LevelController.gateOpenStatus == false)           //gate lock
        {
            Debug.Log("gate");
            notification.text = "Gate is locked";
            StartCoroutine(cooldown());
        }
      
        else if (coolFlag == false)
        {
            if (_open)
            {
                Vector3 pos = transform.position - doorPos;
                iTween.MoveTo(gameObject, pos, 2);
                //transform.position = pos;



                Vector3 rot = transform.rotation.eulerAngles - doorRot;
                iTween.RotateTo(gameObject, rot, 2);
                //transform.rotation = Quaternion.Euler(rot);

                coolFlag = true;
               StartCoroutine( cooldown());

            }
            else
            {
                Vector3 pos = transform.position + doorPos;
                iTween.MoveTo(gameObject, pos, 2);
                // transform.position = pos;

                Vector3 rot = transform.rotation.eulerAngles + doorRot;
                iTween.RotateTo(gameObject, rot, 2);
                // transform.rotation = Quaternion.Euler(rot);

                coolFlag = true;
                StartCoroutine( cooldown());


            }

            _open = !_open;
        }

        if (gameObject.name == "gate" && LevelController.gateOpenStatus == true)
        {
            LevelController.gateOpenedByPlayer = true;
            PlayerAnimations.gateOpenedFlag = true;
        }
    }

    private IEnumerator cooldown()
    {
        
        yield return new WaitForSeconds(2.2f);
        if(notification != null)  notification.text = "";       //gate notification clear
        coolFlag = false;
        
    }



    
	
}
