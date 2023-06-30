using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Initialising Level button 
    private Button _levelButton;
  
    //levelName should be addded to move for the particular level 
    [SerializeField]
    private string levelName;

    void Awake()
    {
        //Getting the component of the Button GameObject
        _levelButton = GetComponent<Button>();
        // adding listener to the level Buttons
        _levelButton.onClick.AddListener(onClickLevel);

        //

       
    }
    // function to load scene with given string
    private void onClickLevel()
    {
        SceneManager.LoadScene(levelName);
        Debug.Log(levelName);
    }
    
}
