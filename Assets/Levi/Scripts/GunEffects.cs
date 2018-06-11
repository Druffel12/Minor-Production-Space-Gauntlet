using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEffects : MonoBehaviour
{
    Light gunLight;
    public GameObject gunParticles;

	void Start ()
    {
        gunLight = GetComponent<Light>();
        gunParticles.SetActive(false);
       // gunParticles = GetComponent<ParticleSystem>();
	}


    public void StartDisable(float t)
    {
        StartCoroutine(disable(t));
    }

    IEnumerator disable(float t)
    {
        yield return new WaitForSeconds(t);
        DisableEffects();
    }

    public void ActivateEffects()
    {
        gunLight.enabled = true;
        gunParticles.SetActive(true);
    }

    public void DisableEffects()
    {
        gunLight.enabled = false;
        gunParticles.SetActive(false);
    }
}
