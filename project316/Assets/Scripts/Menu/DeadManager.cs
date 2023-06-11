using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeadManager : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject menuButton;
    public GameObject exitButton;

    public GameObject hintText;
    public GameObject loadText;
    public GameObject fadeOut;
    public GameObject fadeOutTwo;

    public int loadInt;
    void Start()
    {
        loadInt = PlayerPrefs.GetInt("AutoSave");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        StartCoroutine(RestartLevel());
    }

    public void ToMainMenu()
    {
        StartCoroutine(MainMenuBack());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator RestartLevel()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        loadText.SetActive(true);
        hintText.SetActive(true);
        SceneManager.LoadScene(loadInt);
    }

    IEnumerator MainMenuBack()
    {
        fadeOutTwo.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
