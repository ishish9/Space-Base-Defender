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

    private Vector2 lookControl;
    private float LookControlSpeed = 30f;
    [SerializeField] private Transform[] GunnerPositions;
    ActionMap actionsWrapper;

    private void Awake()
    {
        actionsWrapper = new ActionMap();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        //actionsWrapper.Player.Fire.performed += OnFire;
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

    }

    private void Look()
    {
        lookControl = actionsWrapper.Player.Look.ReadValue<Vector2>();
        float mouseX = lookControl.x * LookControlSpeed * Time.deltaTime;
        float mouseY = lookControl.y * LookControlSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(lookControl.x, lookControl.y,0);
        transform.localRotation = Quaternion.Euler(lookControl.x,lookControl.y,0);
    }
    void Update()
    {
        Look();
        Debug.Log(lookControl);
        // Selects Gunner 1
        if (Input.GetKeyDown("1"))
        {
            transform.position = GunnerPositions[0].position + new Vector3(0,0,0);
        }
        // Selects Gunner 2
        if (Input.GetKeyDown("2"))
        {
            transform.position = GunnerPositions[1].position + new Vector3(0,0,1);
        }
        // Selects Gunner 3
        if (Input.GetKeyDown("3"))
        {
            transform.position = GunnerPositions[2].position + new Vector3(1,0,0);
        }
        // Selects Gunner 4
        if (Input.GetKeyDown("4"))
        {
            transform.position = GunnerPositions[3].position + new Vector3(0,0,-1);
        }
        // Selects Gunner 5
        if (Input.GetKeyDown("5"))
        {
            transform.position = GunnerPositions[4].position + new Vector3(-1,0,0);
        }
                                               
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
