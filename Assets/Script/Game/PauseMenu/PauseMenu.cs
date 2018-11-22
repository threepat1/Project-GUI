using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenu, optionMenu;
    public bool showMenu;
    public AudioSource soundAudio;
    public Light dirLight;

    public Slider soundSlider;
    public Slider lightSlider;

    public GameObject cam1;
    public GameObject mainCam;
    public GameObject player;


    // Use this for initialization
    void Start () {
        
        Time.timeScale = 1f;
        player = GameObject.FindGameObjectWithTag("Player");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");

        soundAudio = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        dirLight = GameObject.Find("Directional Light").GetComponent<Light>();
        soundSlider.value = PlayerPrefs.GetFloat("Audio Source");
        lightSlider.value = PlayerPrefs.GetFloat("Directional Light");

     
        return;

    }

    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
   public void Resume ()
    {
        
        pauseMenu.SetActive(false);
        optionMenu.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<Controller>().enabled = true;
        player.GetComponent<MouseLook>().enabled = true;
        mainCam.GetComponent<MouseLook>().enabled = true;
        GameIsPaused = false;
        

    }
    void Pause()
    {
        
        pauseMenu.SetActive(true);
        optionMenu.SetActive(false);
        Time.timeScale = 0f;

        player.GetComponent<Controller>().enabled = false;
        player.GetComponent<MouseLook>().enabled = false;
        mainCam.GetComponent<MouseLook>().enabled = false;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
       

    }

    public void LoadMenu ()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetFloat("Audio Source", soundAudio.volume);
        PlayerPrefs.SetFloat("Directional Light", dirLight.intensity);
        SceneManager.LoadScene(0);
    }
    public void Exitmenu()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void ToggleOption()
    {
        OptionToggle();
    }
    public void Volume()
    {
        soundAudio.volume = soundSlider.value;
    }
    public void Brightness()
    {
        dirLight.intensity = lightSlider.value;

    }
    bool OptionToggle()
    {
        if (showMenu)
        {
            showMenu = false;
            pauseMenu.SetActive(true);
            optionMenu.SetActive(false);
            return false;

        }
        else
        {

            showMenu = true;
            
            pauseMenu.SetActive(false);
            optionMenu.SetActive(true);
            soundSlider = GameObject.Find("SoundSlider").GetComponent<Slider>();
            lightSlider = GameObject.Find("BrightnessSlider").GetComponent<Slider>();
            
            soundSlider.value = soundAudio.volume;
            lightSlider.value = dirLight.intensity;
            

            return true;
        }

    }
   public void Back()
    {
        showMenu = false;
        pauseMenu.SetActive(true);
        optionMenu.SetActive(false);
        return;
    }
}
