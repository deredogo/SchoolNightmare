using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    public GameObject player;
    public GameObject fadeScreen;
    public GameObject textBox;
    void Start()
    {
        player.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(2.15f);
        fadeScreen.SetActive(false);
        textBox.GetComponent<Text>().text = "What's going on? Where am I???";
        yield return new WaitForSeconds(2.5f);
        textBox.GetComponent<Text>().text = "";
        player.GetComponent<FirstPersonController>().enabled = true;
    }
}
