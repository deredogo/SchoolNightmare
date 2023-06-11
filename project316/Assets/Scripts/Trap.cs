using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    
    public GameObject paper;
    public GameObject realPaper;
    public GenerateEnemies enemies;
    public GameObject door;
    void Start()
    {
        paper.SetActive(false);
        enemies.GetComponent<GenerateEnemies>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            paper.SetActive(true);
            realPaper.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            paper.SetActive(false);
            Destroy(realPaper);
            Destroy(paper);
            enemies.Enemies();
            

        }
    }

}
