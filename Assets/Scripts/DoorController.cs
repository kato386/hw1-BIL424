using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor;

    [SerializeField] private string doorOpen = "DoorOpen";

    public PlayerController keyHelperObject;

   
    bool doorOpenedState = false;

    bool objeyeTemasEtti = true;


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            objeyeTemasEtti = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objeyeTemasEtti = false;
        }
    }
    private void Update()
    {
        if (!doorOpenedState && objeyeTemasEtti)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (keyHelperObject.doesHaveKey()){
                    myDoor.Play(doorOpen, 0, 0.0f);
                    doorOpenedState = true;
                }
            }
        }
    }


}
