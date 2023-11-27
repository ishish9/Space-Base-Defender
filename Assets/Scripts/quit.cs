using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class quit : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject loadingtext;
    [SerializeField] private GameObject BaseDestroyedText;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject SkipButton;
    [SerializeField] private GameObject SideMenu;
    [SerializeField] private CameraControl script1;
    [SerializeField] private RoundManager script2;
    [SerializeField] private gun1 script3;
    [SerializeField] private bool Xactive = false;
    private bool BaseDestroyed = false;
    public bool introPlaying = true;
    ActionMap actionsWrapper;
    public UnityEvent MenuSelectEvent;

    private void Awake()
    {
        actionsWrapper = new ActionMap();
        actionsWrapper.Menu.MenuButton.performed += OnMenuButton;
    }
    void Start()
    {       
        if (MenuSelectEvent == null)
        {
            MenuSelectEvent = new UnityEvent();
        }
    }

    public void OnEnable()
    {
        actionsWrapper.Menu.Enable();
    }

    public void OnDisable()
    {
        actionsWrapper.Menu.Disable();
    }

    public void OnMenuButton(InputAction.CallbackContext context)
    {
        if (introPlaying == false)
        {
            //Activates Menu
            if (menuUI.activeSelf == false)
            {
                MenuSelectEvent.Invoke();
                SideMenu.SetActive(false);
                script3.SideMenuActive = false;
                menuUI.gameObject.SetActive(true);
                BaseDestroyedText.SetActive(false);
                script1.MenuOn();
                restartButton.SetActive(false);        
            }
            else
            {
                // Deactivates Menu
                if (BaseDestroyed == true)
                {
                    BaseDestroyedText.SetActive(true);
                    restartButton.SetActive(true);
                }
                script3.SideMenuActive = true;
                menuUI.gameObject.SetActive(false);
                script1.MenuOff();
            }                     
        }     
    }

    public void xActive()
    {
        if (Input.GetKeyDown(KeyCode.X) && Xactive == true)
        {
            script2.SkipIntro();
            introPlaying = false;
            SkipButton.SetActive(false);
        }
    }

    public void LoadMenu()
    {
        loadingtext.SetActive(true);
        SceneManager.LoadScene("Menu");
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void BaseDestroyedtrue()
    {
        BaseDestroyed = true;
    }

    public void BaseDestroyedfalse()
    {
        BaseDestroyed = false;
    }

    public bool ReturnDestroyedStatues()
    {
        return BaseDestroyed = true;
    }
}

