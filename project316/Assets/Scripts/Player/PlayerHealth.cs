using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth PH;
    public float currentHealth;
    public float maxHealth = 100f;

    public bool isDead = false;

    public FirstPersonController playerScript;

    public Slider healthBarSlider;
    public Text healthText;

    [Header("Damage Screen")]
    public Color damageColor;
    public Image damageImage;
    bool isTakingDamage = false;
    public float colorSpeed = 5f;

    void Awake()
    {
        PH = this;
    }

    void Start()
    {
        healthText.text = maxHealth.ToString();
        currentHealth = maxHealth;
        healthBarSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
         
        if (isTakingDamage)
        {
            damageImage.color = damageColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, colorSpeed * Time.deltaTime);
        }
        isTakingDamage = false;
    }

    public void DamagePlayer(float damage)
    {
        
       if (currentHealth > 0)
        {
            if (damage >= currentHealth)
            {
                isTakingDamage = true;
                Dead();
            }
            else
            {
                isTakingDamage = true;
                currentHealth -= damage;
                healthBarSlider.value -= damage;
                UpdateText();
            }

        }
    }

    public void UpdateText()
    {
        healthText.text = currentHealth.ToString();
    }

    void Dead()
    {
        currentHealth = 0;
        isDead = true;
        healthBarSlider.value = 0;
        UpdateText();
        SceneManager.LoadScene(3);
        playerScript.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
