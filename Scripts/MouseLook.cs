using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    //SKRYPT ODPOWIEDZIALNY ZA OBRACANIE MYSZKĄ
	public enum Rotationaxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public Rotationaxes axes = Rotationaxes.MouseXandY;
    public static float sensitivityHor = 9.0f;
    public static float sensitivityVert = 9.0f;

    public float miniumumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;

    private void Start()
    {
        //Ustawiamy aby ruch myszką nie był zależny od fizyki w grze
        Rigidbody body = GetComponent<Rigidbody>();
        if(body!= null)
        {
            body.freezeRotation = true;
        }
    }


    void Update () {
        //rotacja pozioma
		if(axes == Rotationaxes.MouseX)
        {
            //Input.getaxis pomnożony przez szybkość rotacji == wynik ruchu myszką
            transform.Rotate(0,Input.GetAxis("Mouse X")* sensitivityHor/2,0);
        }
        //rotacja pionowa
        else if(axes == Rotationaxes.MouseY)
        {

            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert/2;
            //Mathf.Clap utrzymuje zmienną w okreslonych granicach
            _rotationX = Mathf.Clamp(_rotationX, miniumumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        //rotacja pionowa i pozioma
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert/2;
            _rotationX = Mathf.Clamp(_rotationX, miniumumVert, maximumVert);

            //delta okresli o jaka wartość zmienił się kąt
            float delta = Input.GetAxis("Mouse X") * sensitivityHor/2;
            //inkrementacja kąta rotacji o deltę 
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);


        }



	}
}
