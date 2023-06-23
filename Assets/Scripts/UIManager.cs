using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField]
    private GameObject optioncanvas; // Reference to the canvas you want to toggle
    [SerializeField]
    private GameObject controlcanvas; // Reference to the canvas you want to toggle
    [SerializeField]
    private GameObject audiocanvas; // Reference to the canvas you want to toggle
    [SerializeField]
    private GameObject levelLoadercanvas; // Reference to the canvas you want to toggle
    [SerializeField]
    private Button _closePopBtn;


    // Method to toggle the canvas on or off
    public void ToggleOptionsCanvas()
    {
        
        optioncanvas.SetActive(true);
       // canvas.enabled = !canvas.enabled;
    }
    public void ToggleControlCanvas()
    {
        optioncanvas.SetActive(false);
        controlcanvas.SetActive(true);
    }
    public void ToggleAudioCanvas()
    {
        optioncanvas.SetActive(false);
        audiocanvas.SetActive(true);
    }
    public void BackToMenu()
    {
        
        optioncanvas.SetActive(false);
    }
    public void BackToOptions()
    {
       
        controlcanvas.SetActive(false);
        audiocanvas.SetActive(false);
        optioncanvas.SetActive(true);
    }
    public void exitApp()
    {
        Application.Quit();
    }
    public void startLevel()
    {
        // optioncanvas.SetActive(false);
        // SceneManager.LoadScene("LevelScreen");
        levelLoadercanvas.SetActive(true);
    }
    public void panelPopout()
    {
        levelLoadercanvas.SetActive(false);
    }

}
