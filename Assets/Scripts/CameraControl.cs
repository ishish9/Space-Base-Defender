using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class CameraControl : MonoBehaviour
{
   // private float rotationX = 0f;
   // private float rotationY = 0f;
    public float sensitivity = 15f;
    public Texture2D cursor;
    public bool shake = false;
    private float shakeduration = 0.1f;
    public gun1 script1;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    private int gunnerNumber;

    [SerializeField]private Vector2 lookControl;
    private float LookControlSpeed = 30f;
    [SerializeField] private Transform[] GunnerPositions;
    ActionMap actionsWrapper;

    private void Awake()
    {
        actionsWrapper = new ActionMap();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        //actionsWrapper.Player.Fire.performed += OnFire;
        actionsWrapper.Player.SwitchGunner.performed += OnSwitchGunner;

    }

    public void OnEnable()
    {
        actionsWrapper.Player.Enable();
    }
    
    public void OnDisable()
    {
        actionsWrapper.Player.Disable();
    }

    public void OnSwitchGunner(InputAction.CallbackContext context)
    {
        gunnerNumber++;
        switch (gunnerNumber)
        {
            // Selects Gunner view.
            case 0:
                transform.position = GunnerPositions[0].position + new Vector3(0, 0, 0);
                break;
            case 1:
                transform.position = GunnerPositions[1].position + new Vector3(0, 0, 1);
                break;
            case 2:
                transform.position = GunnerPositions[2].position + new Vector3(1, 0, 0);
                break;
            case 3:
                transform.position = GunnerPositions[3].position + new Vector3(0, 0, -1);
                break;
            case 4:
                transform.position = GunnerPositions[4].position + new Vector3(-1, 0, 0);
                break;        
        }
    }


    void Update()
    {
        lookControl = actionsWrapper.Player.Look.ReadValue<Vector2>() * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(lookControl.x,lookControl.y,0);                                                   
        if (shake)
        {
            shake = false;
            StartCoroutine(ShakeScreen());
        }
    }

    IEnumerator ShakeScreen()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < shakeduration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = startPosition + Random.insideUnitSphere;
            yield return null;
        }
        transform.position = startPosition;
    }

    public void MenuOn()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        script1.gunActive = false;
        OnDisable();
    }

    public void MenuOff()
    {      
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        if (script1.scannerActive == false)
        {
            script1.gunActive = true;
        }
        else
        {
            script1.gunActive = false;
        }
        OnEnable();
    }

    public void QMenuOn()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void QMenuOff()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

   
}
