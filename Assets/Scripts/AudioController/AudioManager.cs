using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // Audio players components.
    //public AudioSource EffectsSource;
    
    [SerializeField]
    private AudioSource GamePlaySource;

   // public AudioSource[] sfxSources;
    [SerializeField]
    private AudioSource CollectableSource;
    [SerializeField]
    private AudioSource meleehurtSource;
    [SerializeField]
    private AudioSource playerHurtSource;
    [SerializeField]
    private AudioSource doorTouchSource;
    [SerializeField]
    private AudioSource menuOverSource;
    [SerializeField]
    private AudioSource deathSource;
    [SerializeField]
    private AudioSource swordSwingSource;
    [SerializeField]
    private AudioSource levelCompleteSource;

    // Random pitch adjustment range.
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;

    private float savedVolume; // To store the volume setting in PlayerPrefs

    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    // Singleton instance.
    public static AudioManager Instance = null;

    // Initialize the singleton instance.
    private void Awake()
    {
        makeSingleton();
        
        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
        
    }
    private void Start()
    {
        

        // Find all AudioSource components in the scene and set their volume
        /* AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
         foreach (AudioSource audioSource in allAudioSources)
         {
             if (audioSource != GamePlaySource)
             {
                 audioSource.volume = savedVolume;
             }
         }*/


    }
    private void makeSingleton()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        // Load the saved volume settings from PlayerPrefs (if available)
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // Set the slider values to the loaded volume settings
        masterVolumeSlider.value = masterVolume;
        musicVolumeSlider.value = musicVolume;
        sfxVolumeSlider.value = sfxVolume;

        // Add listeners to the sliders to update the volumes when they change
        masterVolumeSlider.onValueChanged.AddListener(UpdateMasterVolume);
        musicVolumeSlider.onValueChanged.AddListener(UpdateMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(UpdateSFXVolume);

        // Apply the initial volume settings
        ApplyVolumeSettings();

    }

    // Play a single clip through the sound effects source.
    public void gamePlay(AudioClip clip)
    {
        GamePlaySource.clip = clip;
        GamePlaySource.Play();
    }

    // Play a single clip through the music source.
    public void PlayCollectable(AudioClip clip)
    {
        
        CollectableSource.clip = clip;
        CollectableSource.Play();
    }
    
    public void playerHurtSound(AudioClip clip)
    {

        playerHurtSource.clip = clip;
        playerHurtSource.Play();
    }

    public void meleehurt(AudioClip clip)
    {
       // Debug.Log("sound");
        meleehurtSource.clip = clip;
        meleehurtSource.Play();
    }
    
    public void swordSwingSound(AudioClip clip)
    {
        //  Debug.Log("sound");
        swordSwingSource.clip = clip;
        swordSwingSource.Play();
    }
    
    public void levelComplete(AudioClip clip)
    {
        //  Debug.Log("sound");
        levelCompleteSource.clip = clip;
        levelCompleteSource.Play();
    }
    public void doorTouch(AudioClip clip)
    {

        doorTouchSource.clip = clip;
        doorTouchSource.Play();
    }
    public void menuOver(AudioClip clip)
    {

        menuOverSource.clip = clip;
        menuOverSource.Play();
    }
    public void playeDeath(AudioClip clip)
    {
        deathSource.clip = clip;
        deathSource.Play();
    }
    /* public void setVolume(float volValue)
     {
         GamePlaySource.volume = volValue;

     }
     public void MasterVolume(float newVolume)
     {
         // AudioListener.volume = newVolume;
         AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
         foreach (AudioSource audioSource in allAudioSources)
         {

                 audioSource.volume = newVolume;
               //PlayerPrefs.SetFloat("Volume", newVolume);
         }
     }*/
    public void sfxVolume(float newVolume)
     {
        // Debug.Log(newVolume);
         AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
         foreach (AudioSource audioSource in allAudioSources)
         {
             if (audioSource != GamePlaySource)
             {
                 audioSource.volume = newVolume;
             }
             // audioSource.volume = newVolume;
            // PlayerPrefs.SetFloat("Volume", newVolume);
         }
     }

    void ApplyVolumeSettings()
    {
        // Apply the volume settings to the appropriate audio listeners or audio sources
        AudioListener.volume = masterVolumeSlider.value;
        GamePlaySource.volume = musicVolumeSlider.value;

       /* for (int i = 0; i < sfxSources.Length; i++)
        {
            sfxSources[i].volume = sfxVolumeSlider.value;
        }*/


       /* AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource != GamePlaySource)
            {
                audioSource.volume = sfxVolumeSlider.value;
            }
            // audioSource.volume = newVolume;
            // PlayerPrefs.SetFloat("Volume", newVolume);
        }*/
        //AudioListener.volume = sfxVolumeSlider.value;

        // Add your own code to adjust the music and SFX volumes in the game
        // For example, you might have separate AudioSources for music and SFX and set their volumes accordingly.
    }
    void UpdateMasterVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("MasterVolume", newVolume);
       // AudioListener.volume = masterVolumeSlider.value;
         ApplyVolumeSettings();
    }

    void UpdateMusicVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("MusicVolume", newVolume);
        //GamePlaySource.volume = musicVolumeSlider.value;
       ApplyVolumeSettings();
    }

    void UpdateSFXVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("SFXVolume", newVolume);
        ApplyVolumeSettings();
               
    }

}
