using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar_Enemy : MonoBehaviour
{
    private Slider slider;
    public ParticleSystem DestroyedExplosion;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    public void SubtractHealth(int DamageAmount)
    {
        slider.value = slider.value - DamageAmount;

        if (slider.value <= 0)
        {
            DestroyedExplosion.Play();
        }
    }
}

