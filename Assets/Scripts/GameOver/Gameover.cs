using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Hide and show the GameOver as the player is dead
/// The gameover panel has restart and Lobby Button
/// </summary>
public class Gameover : MonoBehaviour
{
    /// <summary>
    /// GameOver gameobject is hidden and reveals when palyer dies.
    /// The GameOver contains Restart and Lobby button to load their respective levels 
    /// </summary>
    //adding the _btnRestart from the inspector panel
    [SerializeField]
    private Button _btnLobby;
    [SerializeField]
    private Button _btnQuit;

    private void Awake()
    {
        //Click Listener is added to the Reload 
        _btnLobby.onClick.AddListener(LobbyScreen);
        _btnQuit.onClick.AddListener(QuitGame);

    }
    // When player is dead , GameOver object is set to true
    public void PlayerDied()
    {
       gameObject.SetActive(true);
    }
    //Reloading the same level when Restart button is Clicked
    private void ReloadLevel()
    {
        //getting the Currentscene from Editor
        Scene scene = SceneManager.GetActiveScene();
        //loading the currentscene
        SceneManager.LoadScene(scene.buildIndex);
    }
    private void LobbyScreen()
    {
       // Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(0);
        //Resetting all unlocked levels
        PlayerPrefs.DeleteAll();
    }
        public void QuitGame()
    {
        //Quitting the Application i.e Game
        Application.Quit();
    }

    
}
