using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{


    Rigidbody rigidbody;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();
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

            if (!audioSource.isPlaying)
            {

                audioSource.Play();
            }
            
            print("thrusting");
        }
        else
        {

            audioSource.Stop();
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
