using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {
    [SerializeField] Animator animator;


    public static bool flag = false;
    private float time = 0;
    public static bool gateOpenedFlag = false;
	
	void Update () {
        time += Time.deltaTime;

        if (time > 5.9 && time < 6.1)
        {
            animator.enabled = false;
            gameObject.transform.rotation = new Quaternion (0,0,0,0);
        }
        else if (flag == true)
        {
            animator.enabled = true;
        }
        

        if(gateOpenedFlag == true)
        {
            
        }

	}
}
