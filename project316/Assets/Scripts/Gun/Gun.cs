using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    RaycastHit hit;
    Animator anim;
    public ParticleSystem[] muzzleFlashes;
    public AudioSource gunAS;
    public AudioClip emptyFire;
    public AudioClip ammoChange;
    public AudioClip ammoChange2;
    public AudioClip ammoChange3;



    [System.Serializable]
    public class AmmoType
    {
        public int maxAmmo;
        public int currentAmmo;
        public int carriedAmmo;
        public float damage;
        public string enemyTag;
        public ParticleSystem muzzleFlash;
        public AudioClip shootAC;
        public float rateOfFire;
    }

    public List<AmmoType> ammoTypes;
    public int currentAmmoType = 0;
    bool isReloading;

    public bool isFirstGun;
    public bool isSecondGun;
    public bool isBossGun;

    float nextFire = 0;
    [SerializeField] float weaponRange;
    public Transform shootPoint;

    public Text currentAmmoText;
    public Text carriedAmmoText;

    public GameObject bloodEffect;

    void Start()
    {
        UpdateAmmoUI();
        isFirstGun = true;
        anim = GetComponent<Animator>();
        foreach (var muzzleFlash in muzzleFlashes)
        {
            muzzleFlash.Stop();
        }
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && ammoTypes[currentAmmoType].currentAmmo > 0 && !isReloading)
        {
            Shoot();
        }
        else if (Input.GetButton("Fire1") && ammoTypes[currentAmmoType].currentAmmo <= 0 && !isReloading)
        {
            EmptyFire();
        }
        else if (Input.GetKeyDown(KeyCode.R) && ammoTypes[currentAmmoType].currentAmmo < ammoTypes[currentAmmoType].maxAmmo && !isReloading)
        {
            isReloading = true;
            Reload();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeAmmoType(0);
            gunAS.PlayOneShot(ammoChange);
            isFirstGun = true;
            isSecondGun = false;
            isBossGun = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeAmmoType(1);
            gunAS.PlayOneShot(ammoChange2);
            isFirstGun = false;
            isSecondGun = true;
            isBossGun = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeAmmoType(2);
            gunAS.PlayOneShot(ammoChange3);
            isFirstGun = false;
            isSecondGun = false;
            isBossGun = true;
        }
    }

    void Shoot()
    {
        if ( Time.time > nextFire)
        {
            nextFire = Time.time +  ammoTypes[currentAmmoType].rateOfFire;
            anim.SetTrigger("Shoot");
            ammoTypes[currentAmmoType].currentAmmo--;
            ShootRay();
            UpdateAmmoUI();
            StartCoroutine(GunEffect(ammoTypes[currentAmmoType].shootAC, ammoTypes[currentAmmoType].muzzleFlash));
        }
    }

    void ShootRay()
    {
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, weaponRange))
        {
            if (hit.transform.CompareTag(ammoTypes[currentAmmoType].enemyTag))
            {
                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
                Instantiate(bloodEffect, hit.point, transform.rotation);
                enemy.ReduceHealth(ammoTypes[currentAmmoType].damage);
                StartCoroutine(GunEffect(ammoTypes[currentAmmoType].shootAC, ammoTypes[currentAmmoType].muzzleFlash));
            }
        }
        else
        {
            Debug.Log("Something Else");
        }
    }

    void Reload()
    {
        if (ammoTypes[currentAmmoType].carriedAmmo <= 0) return;
        anim.SetTrigger("Reload");
        StartCoroutine(ReloadCountDown(2f));
    }

    public void UpdateAmmoUI()
    {
        currentAmmoText.text = ammoTypes[currentAmmoType].currentAmmo.ToString();
        carriedAmmoText.text = ammoTypes[currentAmmoType].carriedAmmo.ToString();
    }

    
    

    void EmptyFire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time +  ammoTypes[currentAmmoType].rateOfFire;
            gunAS.PlayOneShot(emptyFire);
            anim.SetTrigger("Empty");
        }
    }

    IEnumerator GunEffect(AudioClip shootAudioClip, ParticleSystem muzzleFlash)
    {
        muzzleFlash.Play();
        gunAS.PlayOneShot(shootAudioClip);
        yield return new WaitForSeconds(shootAudioClip.length);
        muzzleFlash.Stop();
    }

    IEnumerator ReloadCountDown(float timer)
    {
        
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        if (timer <= 0)
        {
            isReloading = false;
            int bulletNeeded = ammoTypes[currentAmmoType].maxAmmo - ammoTypes[currentAmmoType].currentAmmo;
            int bulletsToDeduct = Mathf.Min(bulletNeeded, ammoTypes[currentAmmoType].carriedAmmo);

            ammoTypes[currentAmmoType].carriedAmmo -= bulletsToDeduct;
            ammoTypes[currentAmmoType].currentAmmo += bulletsToDeduct;

            UpdateAmmoUI();
        }
    }

    void ChangeAmmoType(int ammoType)
    {
        if (ammoType >= 0 && ammoType < ammoTypes.Count)
        {
            currentAmmoType = ammoType;
            UpdateAmmoUI();
        }
    }
}

