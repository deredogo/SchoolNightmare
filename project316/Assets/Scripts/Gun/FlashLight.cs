using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light flight;
    public bool drainOverTime;
    public float maxBrightness;
    public float minBrightness;
    public float drainRate;

    public AudioSource flashAS;
    public AudioClip flashAC;

    void Start()
    {
        flashAS = GetComponent<AudioSource>();
        flight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flight.enabled = !flight.enabled;
            flashAS.PlayOneShot(flashAC);
        }

        if (drainOverTime == true && flight.enabled == true)
        {
            flight.intensity = Mathf.Clamp(flight.intensity, minBrightness, maxBrightness);
            if (flight.intensity > minBrightness)
            {
                flight.intensity -= Time.deltaTime * (drainRate / 1000);

            }
        }
        else if (drainOverTime == true && flight.enabled == false)
        {
            if (flight.intensity < maxBrightness)
            {
                flight.intensity += Time.deltaTime * (drainRate / 1000);
            }
        }


    }
}
