using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAmmoGenerate : MonoBehaviour
{
    public GameObject theAmmo;
    public int xPos;
    public int zPos;
    public int ammoCount;

    void Start()
    {
        StartCoroutine(AmmoDrop());
    }

   

    IEnumerator AmmoDrop()
    {
        while (ammoCount < 50)
        {
            xPos = Random.Range(10, 21);
            zPos = Random.Range(-13, 12);
            Instantiate(theAmmo, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(6f);
            ammoCount += 1;
        }
    }



}

