using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InspectManager : MonoBehaviour
{
    public float distance;
    public Transform playerSocket;
    Vector3 originalPos;
    public bool onInspect = false;
    GameObject inspected;

    public FirstPersonController playerScript;
    public GameObject activisonKey;
    public GameObject dropKey;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, distance))
        {
            if (hit.transform.tag == "Object")
            {
                activisonKey.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inspected = hit.transform.gameObject;
                    originalPos = hit.transform.position;
                    onInspect = true;
                    StartCoroutine(PickupItem());

                }
               
            }
            else
            {
                activisonKey.SetActive(false);
            }
        }

        if (onInspect)
        {
            inspected.transform.position = Vector3.Lerp(inspected.transform.position, playerSocket.position, 0.2f);
            playerSocket.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 125f);

        }
        else if (inspected != null)
        {
            inspected.transform.SetParent(null);
            inspected.transform.position = Vector3.Lerp(inspected.transform.position, originalPos, 0.2f);

        }
        if (Input.GetKeyDown(KeyCode.G) && onInspect)
        {
            StartCoroutine(DropItem());
            onInspect = false;

        }

        IEnumerator PickupItem()
        {
            playerScript.enabled = false;
            dropKey.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            inspected.transform.SetParent(playerSocket);
        }
        IEnumerator DropItem()
        {
            inspected.transform.rotation = Quaternion.identity;
            yield return new WaitForSeconds(0.2f);
            playerScript.enabled = true;
            dropKey.SetActive(false);
        }

    }
}
