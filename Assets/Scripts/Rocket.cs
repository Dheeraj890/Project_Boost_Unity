using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{


    Rigidbody rigidbody;

    AudioSource audioSource;

    [SerializeField] float rcsThrust = 100f;

    [SerializeField] float mainThrust = 100f;


    [SerializeField] AudioClip  mainEngine ;

    [SerializeField] AudioClip success;


    [SerializeField] AudioClip death;




    [SerializeField] ParticleSystem mainEngineParticles;

    [SerializeField] ParticleSystem successParticles;


    [SerializeField] ParticleSystem deathParticles;


    private State state;

    enum State { Alive,Dying,Transcending}

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


        if (state == State.Alive) { 
            RespondToRotateInput();
            RespondToThrustInput();

        }
    }

    private void RespondToRotateInput()
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


        if (state != State.Alive)

            return;


        switch (collision.gameObject.tag)
        {
            case "Friendlly":
                   print("Collided");

                break;

            case "Finish":
                StartStartSequence();
                break;

            default:
                StartDeathSequence();

                break;
        }
    }

    private void StartDeathSequence()
    {
        print("dead");
        state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(death);
        Invoke("LoadFirstLevel", 1f);
    }

    private void StartStartSequence()
    {
        print("Hi Finish");
        state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        //delay the next scene to load
        Invoke("LoadNextScene", 1f);
    }

    private void LoadNextScene()
    {
                SceneManager.LoadScene(1);


    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);


    }

    private void RespondToThrustInput()
    {


        rigidbody.freezeRotation = true;//Take control of mannual rotation
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();
        }
        else
        {

            audioSource.Stop();
            mainEngineParticles.Stop();

        }

        rigidbody.freezeRotation = false;//resume physics control of rotation
    }

    private void ApplyThrust()
    {
        rigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        if (!audioSource.isPlaying)
        {


            //Playing the specific audio clip
            audioSource.PlayOneShot(mainEngine);
        }

        print("thrusting");

        mainEngineParticles.Play();
    }
}
