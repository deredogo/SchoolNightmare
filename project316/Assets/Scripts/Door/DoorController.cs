using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator anim;
    public float theDistance;
    public bool isDoorOpen = false;
    public GameObject actionKey;
    public AudioSource doorSound;
    public GameObject activeCross;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
    }

    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            actionKey.SetActive(true);
            activeCross.SetActive(true);

           
        }
        else
        {
            actionKey.SetActive(false);
            activeCross.SetActive(false);

        }

        if (Input.GetButton("Action"))
        {
            if (theDistance <= 2 && isDoorOpen == false)
            {

                actionKey.SetActive(false);
                anim.SetBool("isOpen", true);
                doorSound.Play();
                isDoorOpen = true;

            }
            else if (theDistance <= 2 && isDoorOpen == true)
            {
             
                anim.SetBool("isOpen", false);
                doorSound.Play();
                isDoorOpen = false;
            }


        }

    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        activeCross.SetActive(false);
    }
}