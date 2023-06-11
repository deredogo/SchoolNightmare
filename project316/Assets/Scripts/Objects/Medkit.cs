using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit: MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject fulHealthText;
    public GameObject activeCross;
    public GameObject medkitBox;

    PlayerHealth player;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }



    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
    }

    void OnMouseOver()
    {
        if (theDistance <= 6)
        {
            if (player.currentHealth == 100)
            {
                actionKey.SetActive(false);
                activeCross.SetActive(true);
                fulHealthText.SetActive(true);
            }
            else if (player.currentHealth < 100)
            {
                actionKey.SetActive(true);
                activeCross.SetActive(true);
                fulHealthText.SetActive(false);
            }
           
        }
        else
        {
            actionKey.SetActive(false);
            activeCross.SetActive(false);
        }

        if (Input.GetButton("Action"))
        {
            if (theDistance <= 6)
            {
                if (player.currentHealth < 100)
                {
                    player.currentHealth += 25;
                    player.UpdateText();
                    player.healthBarSlider.value += 25;
                    actionKey.SetActive(false);
                    activeCross.SetActive(false);
                    Destroy(medkitBox);
                }
                
   
            }


        }

    }

   

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        activeCross.SetActive(false);
        fulHealthText.SetActive(false);

    }
}
