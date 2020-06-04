using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{


    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {

        if (Input.GetKey(KeyCode.Space))
        {


            rigidbody.AddRelativeForce(Vector3.up);
            print("thrusting");
        }

        if (Input.GetKey(KeyCode.A))
        {

            transform.Rotate(Vector3.forward);
            print("rotating left");
        }

        if (Input.GetKey(KeyCode.D))
        {

            transform.Rotate(-Vector3.forward);


            print("rotating right");
        }
    }
}
