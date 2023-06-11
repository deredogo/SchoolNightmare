using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    Animator anim;
    public float theDistance;
    public GameObject actionText;
    public GameObject actionKey;
    public AudioSource doorSound;
    public GameObject activeCross;
    public bool isDoorOpen = false ;
    public float waitingTime;
    GetKey key;
    public string keyNeededTag;
    public bool isRightKey;

    void Start()
    {
        anim = GetComponent<Animator>();
        key = FindObjectOfType<GetKey>();
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

        if (key.isKeyObtained == true && keyNeededTag == key.keyTag)
        {
            isRightKey = true;
        }
        else
        {
            isRightKey = false;
        }
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

        if (Input.GetButton("Action") && isRightKey == true) 
        {
            if (theDistance <= 2 && isDoorOpen == false)
            {

                
                anim.SetBool("isOpened", true);
                doorSound.Play();
                isDoorOpen = true;

            }
            else if (theDistance <= 2 && isDoorOpen == true)
            {

                anim.SetBool("isOpened", false);
                doorSound.Play();
                isDoorOpen = false;
            }

        }else if (Input.GetButton("Action") && isRightKey == false)
        {
            actionKey.SetActive(false);
            actionText.SetActive(true);
            StartCoroutine(closedDoor());
        }

        
    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        activeCross.SetActive(false);

    }

    IEnumerator closedDoor()
    {
        yield return new WaitForSeconds(waitingTime);
        actionText.SetActive(false);
    }
}
