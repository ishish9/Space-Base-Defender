using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private GameObject DestroyedDisplay;
    [SerializeField] private GameObject HealthbarObj;
    [SerializeField] private GameObject ShieldbarObj;
    [SerializeField] private GameObject QuickFadeIn;
    [SerializeField] private GameObject Crosshair;
    [SerializeField] private GameObject ScannerCrosshair;
    [SerializeField] private HealthBar script1;
    [SerializeField] private ShieldBar script2;
    [SerializeField] private CameraControl script3;
    [SerializeField] private ExampleFracture script4;
    [SerializeField] private quit script5;
    [SerializeField] private gun1 script6;
    [SerializeField] private GameObject SpawnManager;

    public void RestartAsteroid()
    {
        AsteroidScore.score = 0;
        script6.ActivateGun();
        DestroyedDisplay.SetActive(false);
        HealthbarObj.SetActive(true);
        ShieldbarObj.SetActive(true);
        QuickFadeIn.SetActive(true);
        Crosshair.SetActive(true);
        SpawnManager.SetActive(true);
        script1.ResetHealth();
        script2.ResetShield();
      
        script4.FireAmountReset();
        script4.FireRateReset();
        script4.RestartCoroutine();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        StartCoroutine(wait());

        IEnumerator wait()
        {
            yield return new WaitForSeconds(2);
            QuickFadeIn.SetActive(false);
        }
    }

    public void RestartMainGame()
    {
        script5.BaseDestroyedfalse();
        AsteroidScore.score = 0;
        script6.ActivateGun();
        DestroyedDisplay.SetActive(false);
        HealthbarObj.SetActive(true);
        ShieldbarObj.SetActive(true);
        QuickFadeIn.SetActive(true);
        Crosshair.SetActive(true);
        ScannerCrosshair.SetActive(false);
        SpawnManager.SetActive(true);
        script1.ResetHealth();
        script2.ResetShield();
        //script4.FireAmountReset();
        //script4.FireRateReset();
        script4.RestartCoroutine();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        StartCoroutine(wait2());

        IEnumerator wait2()
        {
            yield return new WaitForSeconds(2);
            QuickFadeIn.SetActive(false);
        }
    }

}
