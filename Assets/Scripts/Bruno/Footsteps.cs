using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    //[FMODUnity.EventRef]
    public FMODUnity.EventReference inputSound;
    //public string ;
    bool playerIsMoving;
    float timer;
    public float walkingSpeed;
    public CharacterController controller;

    private void Update()
    {
        //Debug.Log("Velocity: " + GetComponent<CharacterController>().velocity);
        if (Input.GetAxis("Vertical") >= .01f || Input.GetAxis("Horizontal") >= .01f ||
            Input.GetAxis("Vertical") <= -.01f || Input.GetAxis("Horizontal") <= -.01f)
        {
            if (controller.velocity.x >= .7f || controller.velocity.x <= -.7f || controller.velocity.z >= .7f
                || controller.velocity.z <= -.7f)
            {
                playerIsMoving = true;
            }
            else
            {
                playerIsMoving = false;
            }
        }
        else if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0)
        {
            playerIsMoving = false;
        }

        if (timer >= walkingSpeed)
        {
            timer = 0;
            callFootSteps();
        }
        timer += Time.unscaledDeltaTime;
    }

    void callFootSteps()
    {
        if (playerIsMoving)
        {
            FMODUnity.RuntimeManager.PlayOneShot(inputSound);
        }
    }

    private void OnDisable()
    {
        playerIsMoving = false;
    }
}
