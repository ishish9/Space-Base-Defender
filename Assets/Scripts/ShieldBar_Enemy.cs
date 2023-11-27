using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShieldBar_Enemy : MonoBehaviour
{
    private Slider slider;
    public Shield_Enemy script1;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    public void SubtractShield(int DamageAmount)
    {
        slider.value = slider.value - DamageAmount;

        if (slider.value <= 0)
        {
           script1.ShieldsDown = true;
        }
    }

    public void Warhead()
    {
        slider.value = 0;
    }
}
