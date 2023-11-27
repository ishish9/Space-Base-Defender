using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shield_Enemy : MonoBehaviour
{
    public ShieldBar_Enemy script1;
    public HealthBar_Enemy script2;
    public bool ShieldsDown = false;
    [SerializeField] private MeshRenderer meshRender;

    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (ShieldsDown == false)
        {
            if (collision.gameObject.tag == "EMP")
            {
                script1.SubtractShield(2);
                enemy_projectile.impactSelect = 0;
            }
            else
            {
                script1.SubtractShield(6);
                enemy_projectile.impactSelect = 0;
            }            
        }
        else
        {
            meshRender.enabled = false;

            if (collision.gameObject.tag == "EMP")
            {
                script2.SubtractHealth(3);
                enemy_projectile.impactSelect = 1;
            }
            else
            {
                script2.SubtractHealth(10);
                enemy_projectile.impactSelect = 1;
            }           
        }

        if (collision.gameObject.tag == "Warhead")
        {     
            
        }
    }
}
