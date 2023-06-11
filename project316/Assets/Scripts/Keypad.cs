using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Keypad : MonoBehaviour
{
    public GateController doorToOpen;
    public GameObject keypadUI;
    public Text passwordText;
    public string password;
    public GameObject dropText;
    public GameObject health;

    public FirstPersonController playerScript;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.G))
        {
            playerScript.enabled = true;
            keypadUI.SetActive(false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            keypadUI.SetActive(true);
            playerScript.enabled = false;
            health.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            dropText.SetActive(true);

        }
    }

    public void KeyButton(string key)
    {
        passwordText.text = passwordText.text + key;
    }
    public void ResetPassword()
    {
        passwordText.text = "";
    }
    public void CheckPassword()
    {
        if (passwordText.text == password)
        {
            doorToOpen.isDoorLocked = false;
            doorToOpen.CheckDoor();
            keypadUI.SetActive(false);
            health.SetActive(true);
            playerScript.enabled = true;
        }
        else
        {
            ResetPassword();
        }
    }
}
