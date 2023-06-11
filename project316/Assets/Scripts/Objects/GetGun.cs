using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGun : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    //public AudioSource doorSound;
    public GameObject activeCross;
    public GameObject gun;
    public GameObject realGun;
    public GameObject ammoPanel;
    public GameObject realFlight;


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
            if (theDistance <= 2)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                actionKey.SetActive(false);
                //doorSound.Play();
                realGun.SetActive(true);
                ammoPanel.SetActive(true);
                activeCross.SetActive(false);
                Destroy(gun);
                realFlight.SetActive(true);

            }


        }

    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        activeCross.SetActive(false);

    }

   

    
}
