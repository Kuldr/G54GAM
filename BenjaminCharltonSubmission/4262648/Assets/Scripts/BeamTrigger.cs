using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamTrigger : MonoBehaviour
{
    Renderer rend;
    ParticleSystem particle;
    public Door doorObject;
    int collidingObjects = 0;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        particle = GetComponent<ParticleSystem>();
        particle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Beam");

        //Disable Rendering of the beam
        rend.enabled = false;
        particle.Clear();
        particle.Stop();

        if( collidingObjects == 0) {
            //Trigger the door object
            doorObject.Trigger();
        }

        collidingObjects++;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exitted Beam");

        //Enable Rendering of the beam
        rend.enabled = true;
        particle.Play();

        if (collidingObjects == 1)
        {
            //Trigger the door object
            doorObject.Trigger();
        }

        collidingObjects--;
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Still Colliding");

        //Disable Rendering of the beam
        rend.enabled = false;
        particle.Clear();
        particle.Stop();
    }
}
