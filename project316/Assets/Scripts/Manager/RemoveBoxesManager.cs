using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBoxesManager : MonoBehaviour
{
    public GameObject boxesRemoved;
    public GameObject stackBox;
    void Start()
    {
        boxesRemoved.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            boxesRemoved.SetActive(true);
            stackBox.SetActive(false);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            boxesRemoved.SetActive(false);

        }
    }

    
}
