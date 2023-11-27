using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Camera : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] private Transform SpawnLocation;
    [SerializeField] private AudioSource click;
    [SerializeField] private Camera cam;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 9500.0f))
        {
            if (hit.collider.tag == "Enemy_Shield")
            {
                click.Play();
            }
        }
    }
}
