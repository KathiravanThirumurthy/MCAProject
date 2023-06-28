using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayBgMusic : MonoBehaviour
{
    [SerializeField]
    private AudioClip bgMusic;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.gamePlay(bgMusic);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
