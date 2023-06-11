using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAmmo : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject activeCross;
    public GameObject canNotTakeText;
    public GameObject gun;
    public GameObject ammoBox;
    public string ammoTag;



    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
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

        if (Input.GetButton("Action"))
        {
            if (theDistance <= 2)
            {
                Gun gunScript = gun.GetComponent<Gun>();
                if (gunScript.isFirstGun && ammoTag == "First")
                {
                    gunScript.ammoTypes[gunScript.currentAmmoType].carriedAmmo += 10;
                    if (gunScript.ammoTypes[gunScript.currentAmmoType].carriedAmmo >= gunScript.ammoTypes[gunScript.currentAmmoType].maxAmmo)
                    {
                        gunScript.ammoTypes[gunScript.currentAmmoType].carriedAmmo = gunScript.ammoTypes[gunScript.currentAmmoType].maxAmmo;

                    }
                    
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    actionKey.SetActive(false);
                    //doorSound.Play();

                    activeCross.SetActive(false);
                    Destroy(ammoBox);
                }
                else if (gunScript.isSecondGun && ammoTag == "Second")
                {

                    gunScript.ammoTypes[gunScript.currentAmmoType].carriedAmmo += 5;
                    if (gunScript.ammoTypes[gunScript.currentAmmoType].carriedAmmo >= gunScript.ammoTypes[gunScript.currentAmmoType].maxAmmo)
                    {
                        gunScript.ammoTypes[gunScript.currentAmmoType].carriedAmmo = gunScript.ammoTypes[gunScript.currentAmmoType].maxAmmo;

                    }
                    
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    actionKey.SetActive(false);
                    //doorSound.Play();

                    activeCross.SetActive(false);
                    Destroy(ammoBox);
                }
                else if (gunScript.isBossGun && ammoTag == "Boss")
                {
                    gunScript.ammoTypes[gunScript.currentAmmoType].carriedAmmo += 2;
                    if (gunScript.ammoTypes[gunScript.currentAmmoType].carriedAmmo >= gunScript.ammoTypes[gunScript.currentAmmoType].maxAmmo)
                    {
                        gunScript.ammoTypes[gunScript.currentAmmoType].carriedAmmo = gunScript.ammoTypes[gunScript.currentAmmoType].maxAmmo;

                    }
                    
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    actionKey.SetActive(false);
                    //doorSound.Play();

                    activeCross.SetActive(false);
                    Destroy(ammoBox);
                }
                else
                {
                    canNotTakeText.SetActive(true);
                    StartCoroutine(canNotTakeAmmo());
                }
                gunScript.UpdateAmmoUI();




            }


        }

    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        activeCross.SetActive(false);

    }

    IEnumerator canNotTakeAmmo()
    {
        yield return new WaitForSeconds(1.2f);
        canNotTakeText.SetActive(false);
    }

}

