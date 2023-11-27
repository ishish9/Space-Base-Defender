using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Settings : MonoBehaviour
{
    [SerializeField] private GameObject loadingtext;
    [SerializeField] private GameObject Prefab;
    [SerializeField] AudioClip chime;
    [SerializeField] AudioClip music;

    void Start()
    {
        AudioManager.Instance.PlayMusic(music);
        AudioManager.Instance.PlaySoundDelayed(chime, 4f);
    }

    public void LowSetting()
    {
        QualitySettings.SetQualityLevel(1, true);
    }

    public void MediumSetting()
    {
        QualitySettings.SetQualityLevel(2, true);
    }

    public void HighSetting()
    {
        QualitySettings.SetQualityLevel(3, true);
    }

    public void VeryHighSetting()
    {
        QualitySettings.SetQualityLevel(4, true);
    }

    public void LoadMenu()
    {
        loadingtext.SetActive(true);
        SceneManager.LoadScene("Menu");
    }

    public void LoadLevel()
    {
        loadingtext.SetActive(true);
        SceneManager.LoadScene("L1");
    }

    public void LoadAsteroidMode()
    {
        loadingtext.SetActive(true);
        SceneManager.LoadScene("Asteroid Mode");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
