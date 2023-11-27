using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundManager : MonoBehaviour
{
    public ExampleFracture script1;
    public CameraControl script2;
    public IntroCam script3;
    public quit script4;
    public GameObject IntroText;
    public GameObject gunObj;
    public GameObject Crosshair;
    public GameObject ActivateSpawner;
    public GameObject Destroy1;
    public GameObject Destroy2;
    public GameObject Destroy3;
    public GameObject Destroy4;
    public GameObject Destroy5;
    public GameObject FadeOut;
    public GameObject FadeIn;
    public GameObject EnableMap;
    public GameObject QuickIn;
    public GameObject MobileGun;
    [SerializeField] private GameObject SkipButton;
    public Transform camera;
    public float timeRemaining;
    private bool timerIsRunning = false;
    private IEnumerator wait;
    private IEnumerator wait2;



    //Enable UI
    public GameObject hbar;
    public GameObject sbar;
    public GameObject count;

    void Start()
    {
        
        Fracture.EnergySpawnActive = false;
        Destroy(IntroText, 20);
        wait = WaitForSeconds(21);
        wait2 = WaitForSeconds2(12);
        StartCoroutine(wait);
        StartCoroutine(wait2);

        IEnumerator WaitForSeconds(int waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            timerIsRunning = true;
            gunObj.SetActive(true);
            Crosshair.SetActive(true);
            ActivateSpawner.SetActive(true);
            
            camera.position = new Vector3(0, 0, 0);
            script3.m_Speed = 0;
            Destroy(Destroy1);
            Destroy(Destroy2);
            Destroy(Destroy3);
            Destroy(Destroy4);
            Destroy(Destroy5);
            FadeOut.SetActive(false);
            FadeIn.SetActive(true);
            hbar.SetActive(true);
            sbar.SetActive(true);
            count.SetActive(true);
            timeRemaining = 60f;
            EnableMap.SetActive(true);
            SkipButton.SetActive(false);
            script4.introPlaying = false;
           // MobileGun.SetActive(true);

        }

        IEnumerator WaitForSeconds2(int waitTime2)
        {
            yield return new WaitForSeconds(waitTime2);
            FadeOut.SetActive(true);
            FadeIn.SetActive(false);
        }
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0f)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time Out");
                timeRemaining = 60f;
                //timerIsRunning = false;
                if (script1.FireRate >= 2)
                {
                    script1.Subtract();
                }
            }
        }
        Debug.Log("Time Remaining " + timeRemaining);
    }
    

    public void SkipIntro()
    {
        StopCoroutine(wait);
        StopCoroutine(wait2);
        timerIsRunning = true;
        gunObj.SetActive(true);
        Crosshair.SetActive(true);
        ActivateSpawner.SetActive(true);
      
        camera.position = new Vector3(0, 0, 0);
        script3.m_Speed = 0;
        Destroy(Destroy1);
        Destroy(Destroy2);
        Destroy(Destroy3);
        Destroy(Destroy4);
        Destroy(Destroy5);
        FadeOut.SetActive(false);
        FadeIn.SetActive(true);
        hbar.SetActive(true);
        sbar.SetActive(true);
        count.SetActive(true);
        timeRemaining = 60f;
        EnableMap.SetActive(true);
        FadeOut.SetActive(false);
        FadeIn.SetActive(false);
        QuickIn.SetActive(true);
        Destroy(IntroText);
        script4.introPlaying = false;
        //MobileGun.SetActive(true);

    }
}
