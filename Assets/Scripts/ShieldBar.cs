using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShieldBar : MonoBehaviour
{
    private Slider slider;
    public Shield script1;
    private bool shieldswereoff = false;
    private bool ShieldsGoOff = false;
    public TextMeshProUGUI BarValueText;

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
            script1.ShieldsDownDisplay.SetActive(true);
            ShieldsGoOff = true;

            if (ShieldsGoOff == true)
            {
                script1.ShieldAlarm.Play();
                script1.ShieldsDownSound.Play();
                ShieldsGoOff = false;
            }
        }
        BarValueText.text = slider.value.ToString();
    }

    public void ResetShield()
    {
        slider.value = 100;
        BarValueText.text = slider.value.ToString();
        script1.ShieldsDown = false;
    }

    public void AddShield(int ShieldAmount)
    {
        if (slider.value <= 0)
        {
            shieldswereoff = true;
        }

        slider.value = slider.value + ShieldAmount;
        if (shieldswereoff == true)
        {
            script1.ShieldAlarm.Stop();
            script1.ShieldsUpSound.Play();
            script1.ShieldsDownDisplay.SetActive(false);
            script1.ShieldsDown = false;
            shieldswereoff = false;
        }
        BarValueText.text = slider.value.ToString();
    }

    public void Warhead()
    {
        slider.value = 0;
    }
}
