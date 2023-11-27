using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;   

public class gun1 : MonoBehaviour
{
    [SerializeField] private Transform SpawnLocation;
    [SerializeField] private Transform RotationAtSpawn;
    //private Vector3 offset = new Vector3(7f, 0f, 0f);
    [SerializeField] private GameObject SideMenu;
    [SerializeField] private GameObject CrossHair;
    [SerializeField] private GameObject ScannerCrossHair;
    [SerializeField] private CameraControl script1;
    [SerializeField] private AudioSource ScannerHit_Snd;
    [SerializeField] private AudioSource scannerMiss_Snd;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject[] Prefab;
    private int WeaponSelection = 0;
    public bool gunActive = true;
    public bool scannerActive = false;
    private float Projectilespeed = 40f;
    public bool SideMenuActive = true;
    ActionMap actionsWrapper;
    public UnityEvent WeaponSelectMenuEvent;

    private void Awake()
    {
        actionsWrapper = new ActionMap();
        actionsWrapper.Player.Fire.performed += OnFire;
        actionsWrapper.Player.WeaponSelectMenu.performed += OnSelectWeapon;
    }
    void Start()
    {      
        if (WeaponSelectMenuEvent == null)
        {
            WeaponSelectMenuEvent = new UnityEvent();
        }
    }

    public void OnEnable()
    {
        actionsWrapper.Player.Enable();
    }

    public void OnDisable()
    {
        actionsWrapper.Player.Disable();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (gunActive)
        {
            if (WeaponSelection == 2)
            {
                RayScannerShoot();
            }
            else
            {
                var bullet = Instantiate(Prefab[WeaponSelection], SpawnLocation.transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().velocity = SpawnLocation.forward * Projectilespeed;
            }
        }
    }

    public void OnSelectWeapon(InputAction.CallbackContext context)
    {
        if (SideMenuActive == true)
        {
            if (SideMenu.activeSelf == false)
            {
                gunActive = false;
                SideMenu.SetActive(true);
                script1.QMenuOn();
            }
            else
            {
                gunActive = true;
                SideMenu.SetActive(false);
                script1.QMenuOff();
            }
        }
        Debug.Log("WeaponSelectedMenu Button Pressed!");
    }

    public void FireWeapon()
    {
        if (gunActive)
        {
            var bullet = Instantiate(Prefab[WeaponSelection], SpawnLocation.position, SpawnLocation.rotation);
            bullet.GetComponent<Rigidbody>().velocity = SpawnLocation.forward * Projectilespeed;
        }    
    }

    public void WeaponSelectEnergyBall()
    {
        WeaponSelection = 0;
        CrossHair.SetActive(true);
        ScannerCrossHair.SetActive(false);
        gunActive = true;
        script1.QMenuOff();
        scannerActive = false;
        SideMenu.SetActive(false);
    }

    public void WeaponSelectEMP()
    {
        WeaponSelection = 1;
        CrossHair.SetActive(true);
        ScannerCrossHair.SetActive(false);
        gunActive = true;
        script1.QMenuOff();
        scannerActive = false;
        SideMenu.SetActive(false);
    }

    public void ResonanceScanner()
    {
        WeaponSelection = 2;
        CrossHair.SetActive(false);
        ScannerCrossHair.SetActive(true);
        gunActive = true;
        script1.QMenuOff();
        scannerActive = true;
        SideMenu.SetActive(false);
    }

    public void ActivateGun()
    {
        gunActive = true;
    }

    public void DeactivateGun()
    {
        gunActive = true;
    }

    void RayScannerShoot()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 9500.0f))
        {
            if (hit.collider.tag == "Enemy_Shield")
            {
                ScannerHit_Snd.Play();
            }
        }
    }
}
