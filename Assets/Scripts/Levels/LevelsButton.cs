using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsButton : MonoBehaviour
{
    [SerializeField]
    private int _sceneIndex;
    [SerializeField]
    private string _levelName;
    public void openScene()
    {
        Debug.Log("Scene Loading");
        //SceneManager.LoadScene(_sceneIndex);
        SceneManager.LoadScene(_levelName);
    }
}
