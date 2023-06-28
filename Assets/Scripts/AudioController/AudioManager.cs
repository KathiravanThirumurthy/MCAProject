using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Audio players components.
    //public AudioSource EffectsSource;
    [SerializeField]
    private AudioSource GamePlaySource;
    [SerializeField]
    private AudioSource CollectableSource;
    [SerializeField]
    private AudioSource doorTouchSource;
    [SerializeField]
    private AudioSource menuOverSource;
    [SerializeField]
    private AudioSource deathSource;


    // Random pitch adjustment range.
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;

    // Singleton instance.
    public static AudioManager Instance = null;

    // Initialize the singleton instance.
    private void Awake()
    {
        makeSingleton();
        
        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
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
        Debug.Log("sound");
        CollectableSource.clip = clip;
        CollectableSource.Play();
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
    
}
