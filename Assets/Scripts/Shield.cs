using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shield : MonoBehaviour
{
    public ShieldBar script1;
    public HealthBar script2;
    public CameraControl script3;
    public GameObject ShieldsDownDisplay;
    public GameObject DeadDisplay;
    public GameObject HealthBar;
    public GameObject ShieldBar;
    public AudioSource ShieldAlarm;
    public AudioSource ShieldsDownSound;
    public AudioSource ShieldsUpSound;
    public bool ShieldsDown = false;

    void OnCollisionEnter(Collision collision)
    {
        script3.shake = true;   

        if (ShieldsDown == false && HealthBar.activeSelf == true)
        {
            script1.SubtractShield(10);
        }
        else
        {
            if (HealthBar.activeSelf == true)
            {
                script2.SubtractHealth(10);
            }
        }

        if (collision.gameObject.tag == "Warhead")
        {     
            script1.Warhead();
            script2.Warhead();
        }
    }
}
