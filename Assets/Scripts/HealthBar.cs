using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    public Shield script1;
    public CameraControl script2;
    [SerializeField] private quit script3;
    public GameObject Crosshair;
    public GameObject gun;
    public TextMeshProUGUI BarValueText;
    public GameObject hbar;
    public GameObject sbar;
    public GameObject restartBtn;
    public ParticleSystem DestroyedExplosion;
    public GameObject SpawnManager;
    public GameObject[] asteroidDelete;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = 100;
    }

    public void SubtractHealth(int DamageAmount)
    {
        slider.value = slider.value - DamageAmount;

        if (slider.value <= 0)
        {
            script3.BaseDestroyedtrue();
            script1.ShieldsDownDisplay.SetActive(false);
            script1.DeadDisplay.SetActive(true);
            script1.ShieldAlarm.Stop();
            Cursor.lockState = CursorLockMode.Locked;
            gun.SetActive(false);
            sbar.SetActive(false);
            Crosshair.SetActive(false);
            restartBtn.SetActive(true);
            SpawnManager.SetActive(false);
           
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            asteroidDelete = GameObject.FindGameObjectsWithTag("Rock");
            DestroyedExplosion.Play();

            for (int i = 0; i < asteroidDelete.Length; i++)
            {
                Destroy(asteroidDelete[i].gameObject);      
            }

        }
        BarValueText.text = slider.value.ToString();
    }

    public void ResetHealth()
    {
        slider.value = 100;
        gun.SetActive(true);
        BarValueText.text = slider.value.ToString();

    }

    public void AddHealth(int HealthAmount)
    {
        slider.value = slider.value + HealthAmount;
        BarValueText.text = slider.value.ToString();
    }

    public void Warhead()
    {
        if (slider.value >= 100)
        {
            slider.value = 50;
        }
        else
        {
            slider.value = slider.value - 70;
        }

        if (slider.value <= 0)
        {
            script3.BaseDestroyedtrue();
            script1.ShieldsDownDisplay.SetActive(false);
            script1.DeadDisplay.SetActive(true);
            script1.ShieldAlarm.Stop();
            Cursor.lockState = CursorLockMode.Locked;
            gun.SetActive(false);
            sbar.SetActive(false);
            Crosshair.SetActive(false);
            restartBtn.SetActive(true);
            SpawnManager.SetActive(false);
          
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            asteroidDelete = GameObject.FindGameObjectsWithTag("Rock");
            DestroyedExplosion.Play();

            for (int i = 0; i < asteroidDelete.Length; i++)
            {
                Destroy(asteroidDelete[i].gameObject);
            }

        }
        BarValueText.text = slider.value.ToString();
    }
}

