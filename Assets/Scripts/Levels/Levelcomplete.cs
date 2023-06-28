using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
/// <summary>
/// When the Level complete it will load the next level 
/// </summary>
public class Levelcomplete : MonoBehaviour
{
    private bool reset;
    public int nextSceneLoad;
    private void Awake()
    {
        reset = false;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        // if the player collides with Ground with tag "Platform"
        if (target.gameObject.GetComponent<Playercontroller>())
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            /*Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex+1);*/
            SceneManager.LoadScene(nextSceneLoad);
            //Setting Int for Index
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }

    }
}
