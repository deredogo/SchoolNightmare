using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey; 
    public GameObject actionText; 
    public GameObject hinge;
    public AudioSource doorSound;
    public GameObject activeCross;
    

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
    }
    
    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            actionKey.SetActive(true);
            actionText.SetActive(true);
            activeCross.SetActive(true);
        }
        else
        {
            actionKey.SetActive(false);
            actionText.SetActive(false);
            activeCross.SetActive(false);
        }
        
        if (Input.GetButton("Action"))
        {
            if (theDistance <= 2)
            {
               
                    actionKey.SetActive(false);
                    actionText.SetActive(false);
                    hinge.GetComponent<Animation>().Play("SmallDoor");
                    doorSound.Play();
                   
            }
            

        }

    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        actionText.SetActive(false);
        activeCross.SetActive(false);

    }


}
