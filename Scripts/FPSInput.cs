using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]  //wymagamy komponentu Character controller
[AddComponentMenu("Control Script/ FPS Input")]   //dodajemy do menu komponentów

public class FPSInput : MonoBehaviour {
    //SKRYPT ODPOWIEDZIALNY ZA PORUSZANIE SIĘ

    


    private CharacterController _charController;
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public float increaseSprint = 1.5f;
    public static bool blockMoving = false;
   





	void Start () {
        _charController = GetComponent<CharacterController>();
	}
	
	
	void Update () {
        if (blockMoving == false)
        {
            float deltaX = Input.GetAxis("Horizontal") * -speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed *= increaseSprint;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed /= increaseSprint;
            }
            Vector3 movement = new Vector3(deltaZ, 0, deltaX);
            //Ograniczenie szybkości ruchu skośnego do takiego samego jak przód i tył
            movement = Vector3.ClampMagnitude(movement, speed);
            movement.y = gravity; //przypisanie grawitacji do ruchu po OY

            movement *= Time.deltaTime;
            //przekształcenie wektora ruchu ze współrzędnych lokalnych na globalne
            movement = transform.TransformDirection(movement);
            //przesuwanie postaci o podany wektor



            _charController.Move(movement);  // Metoda Move() i wektor jej przekazywany odnosi sie do współrzędnych globalnych


            //transform.Translate(deltaX*Time.deltaTime, 0, deltaZ*Time.deltaTime);
        }
	}
}
