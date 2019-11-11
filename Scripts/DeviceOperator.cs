using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour {

    public float radius = 2f;

	
	void Start () {
		
	}
	
	
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);    //zwraca liste obiektow w poblizu 
            foreach(Collider hitCollider in hitColliders)
            {
               // Vector3 direction = hitCollider.transform.position - transform.position;
               // if(Vector3.Dot(transform.forward, direction) > 0.5f)   //sprawdza czy gracz patrzy na drzwi
                    hitCollider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
            }

        }
	}


    public void tryOpen()
    {

    }
}
