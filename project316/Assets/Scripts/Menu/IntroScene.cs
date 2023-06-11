using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    public GameObject textBox;
    public GameObject placeDisplay;
    public GameObject fadeOut;
    public GameObject loadingText;
    public GameObject hintText;

    void Start()
    {
        StartCoroutine(IntroBegin());
    }

    
    IEnumerator IntroBegin()
    {
        yield return new WaitForSeconds(3.2f);
        placeDisplay.SetActive(true);
        yield return new WaitForSeconds(5);
        placeDisplay.SetActive(false);
        yield return new WaitForSeconds(5);

        textBox.GetComponent<Text>().text = "My precious...";
        yield return new WaitForSeconds(3);

        textBox.GetComponent<Text>().text = "Those who dare to steal my precious from me,";
        yield return new WaitForSeconds(5);

        textBox.GetComponent<Text>().text = "MUST BE PUNISHED!";
        yield return new WaitForSeconds(4);

        textBox.GetComponent<Text>().text = "I will punish them using my ultimate inventor abilities.";
        yield return new WaitForSeconds(8);

        textBox.GetComponent<Text>().text = "In this way, I will be able to impress my precious and protect him from danger. <3";
        
        yield return new WaitForSeconds(10);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(17);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        loadingText.SetActive(true);
        hintText.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);




    }
}
