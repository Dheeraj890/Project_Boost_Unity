using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{


    Rigidbody rigidbody;

    AudioSource audioSource;

    [SerializeField] float rcsThrust = 250f;

    //SerializeField] float mainThrust = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Thrusting();

    }

    private void Rotate()
    {

        float rotation = rcsThrust * Time.deltaTime;


        if (Input.GetKey(KeyCode.A))
        {


            transform.Rotate(-Vector3.forward*rotation);
            print("rotating left");
        }

        if (Input.GetKey(KeyCode.D))
        {

            transform.Rotate(Vector3.forward*rotation);


            print("rotating right");
        }
    }


    void OnCollisionEnter(Collision collision)
    {


        switch (collision.gameObject.tag)
        {
            case "Friendlly":
                   print("Collided");

                break;

            case "Fuel":

                break;

            default:

                print("dead");
                break;
        }
    }

    private void Thrusting()
    {


        rigidbody.freezeRotation = true;//Take control of mannual rotation
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

        rigidbody.freezeRotation = false;//resume physics control of rotation
    }
}
