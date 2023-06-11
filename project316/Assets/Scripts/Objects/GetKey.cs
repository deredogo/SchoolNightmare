using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    public float theDistance;
    //public AudioSource doorSound;
    public GameObject activeCross;
    public GameObject key;
    public GameObject getKeyText;
    public bool isKeyObtained;
    public float waitingTime;
    public string keyTag;
    public GameObject glow;
    

    private void Start()
    {
        isKeyObtained = false;
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
    }

    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            activeCross.SetActive(true);
        }
        else
        {
            activeCross.SetActive(false);
        }

        if (Input.GetButton("Action"))
        {
            if (theDistance <= 2)
            {
                isKeyObtained = true;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                getKeyText.SetActive(true);
                StartCoroutine(KeyTakenText());
                //doorSound.Play();

                key.GetComponent<MeshRenderer>().enabled = false;
                Destroy(glow);

            }


        }

    }

    void OnMouseExit()
    {
        activeCross.SetActive(false);

    }

    IEnumerator KeyTakenText()
    {
        yield return new WaitForSeconds(waitingTime);
        getKeyText.SetActive(false);
    }
}
