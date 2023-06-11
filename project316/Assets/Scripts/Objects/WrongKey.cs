using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongKey : MonoBehaviour
{
    public float theDistance;
    //public AudioSource doorSound;
    public GameObject activeCross;
    public GameObject key;
    public GameObject getKeyText;


    private void Start()
    {
        
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
    }

    void OnMouseOver()
    {
        if (theDistance <= 4)
        {
            activeCross.SetActive(true);
        }
        else
        {
            activeCross.SetActive(false);
        }

        if (Input.GetButton("Action"))
        {
            if (theDistance <= 4)
            {
                
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                getKeyText.SetActive(true);
                StartCoroutine(WrongKeyTakenText());
                //doorSound.Play();
                Destroy(key);
                activeCross.SetActive(false);

            }


        }

    }

    void OnMouseExit()
    {
        activeCross.SetActive(false);

    }

    IEnumerator WrongKeyTakenText()
    {
        yield return new WaitForSeconds(1.3f);
        getKeyText.SetActive(false);
    }

}
