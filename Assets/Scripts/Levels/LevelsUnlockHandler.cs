using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsUnlockHandler : MonoBehaviour
{


    [SerializeField]
    private Button[] _levelsbuttons;
    int unlockedLevelsNumber;
    private void Start()
    {
        if(!PlayerPrefs.HasKey("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", 1);

        }
        
        unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocked");
        for (int i = 0; i < _levelsbuttons.Length; i++)
        {

            _levelsbuttons[i].interactable = false;
        }
    }

    private void Update()
    {
        unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocked");
        for (int i = 0; i < unlockedLevelsNumber; i++)
        {

            _levelsbuttons[i].interactable = true;
                    

        }
    }









}
