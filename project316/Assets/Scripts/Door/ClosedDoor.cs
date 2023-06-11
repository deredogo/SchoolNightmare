using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject closedDoorText;
    public AudioSource doorSound;
    public float waitingTime;


    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
    }

    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            actionKey.SetActive(true);
            
        }
        else
        {
            actionKey.SetActive(false);
            
        }

        if (Input.GetButton("Action"))
        {
            if (theDistance <= 2)
            {
                actionKey.SetActive(false);
                closedDoorText.SetActive(true);
                StartCoroutine(closedDoor());
                doorSound.Play();
                

            }
        }

    }
    void OnMouseExit()
    {
        actionKey.SetActive(false);
        

    }

    IEnumerator closedDoor()
    {
        yield return new WaitForSeconds(waitingTime);
        closedDoorText.SetActive(false);
    }
}
